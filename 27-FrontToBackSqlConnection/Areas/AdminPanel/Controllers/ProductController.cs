using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using _27_FrontToBackSqlConnection.Db;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment? env)
        {
            _context = context;
            _env = env;
        }
        [Authorize(Roles = "Admin,Moderator,Member")]
        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Select(product => new ProductGetVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryName = product.Category.Name,
                    SKU = product.SKU,
                    Image = product.ProductImages.FirstOrDefault().Image
                })
                .ToListAsync();

            return View(products);
        }
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync()
            };
            return View(productCreateVM);
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            Product newProduct = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                Description = productCreateVM.Description ?? string.Empty,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage>()
            };

            if (productCreateVM.MainPhoto != null)
            {
                string mainFileName = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                newProduct.ProductImages.Add(new ProductImage { Image = mainFileName, IsPrimary = true });
            }

            if (productCreateVM.HoverPhoto != null)
            {
                string hoverFileName = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                newProduct.ProductImages.Add(new ProductImage { Image = hoverFileName, IsPrimary = false });
            }

            if (productCreateVM.AdditionalPhoto != null && productCreateVM.AdditionalPhoto.Any())
            {
                foreach (var file in productCreateVM.AdditionalPhoto)
                {
                    string additionalFileName = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                    newProduct.ProductImages.Add(new ProductImage { Image = additionalFileName, IsPrimary = null });
                }
            }

            if (productCreateVM.TagIds != null)
            {
                newProduct.ProductTags = new List<ProductTag>();
                foreach (var tagId in productCreateVM.TagIds)
                {
                    newProduct.ProductTags.Add(new ProductTag { TagId = tagId });
                }
            }

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? existProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (existProduct == null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = existProduct.Name,
                Price = existProduct.Price,
                Description = existProduct.Description,
                SKU = existProduct.SKU,
                CategoryId = existProduct.CategoryId,
                TagIds = existProduct.ProductTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync(),
                ProductImages = existProduct.ProductImages
            };

            return View(productUpdateVM);
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            productUpdateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productUpdateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (id == null || id < 1) return BadRequest();

            Product? existProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (existProduct == null) return NotFound();

            productUpdateVM.ProductImages = existProduct.ProductImages;

            if (!ModelState.IsValid) return View(productUpdateVM);

            var deleteImages = existProduct.ProductImages
                .Where(pi => (productUpdateVM.ImageIds == null || !productUpdateVM.ImageIds.Exists(imgId => imgId == pi.Id))
                             && pi.IsPrimary == null)
                .ToList();

            deleteImages.ForEach(di => di.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));

            _context.ProductImages.RemoveRange(deleteImages);

            if (productUpdateVM.ImageIds == null)
            {
                productUpdateVM.ImageIds = new List<int>();
            }

            if (productUpdateVM.MainPhoto != null)
            {
                string fileName = await productUpdateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage mainImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == true);

                if (mainImage != null)
                {
                    mainImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                    existProduct.ProductImages.Remove(mainImage);
                }

                existProduct.ProductImages.Add(new ProductImage { Image = fileName, IsPrimary = true });
            }

            if (productUpdateVM.HoverPhoto != null)
            {
                string hoverFileName = await productUpdateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                ProductImage hoverImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == false);

                if (hoverImage != null)
                {
                    hoverImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                    existProduct.ProductImages.Remove(hoverImage);
                }

                existProduct.ProductImages.Add(new ProductImage { Image = hoverFileName, IsPrimary = false });
            }

            if (productUpdateVM.AdditionalPhoto != null && productUpdateVM.AdditionalPhoto.Any())
            {
                foreach (var file in productUpdateVM.AdditionalPhoto)
                {
                    string additionalFileName = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images");
                    existProduct.ProductImages.Add(new ProductImage { Image = additionalFileName, IsPrimary = null });
                }
            }

            existProduct.ProductTags.Clear();
            if (productUpdateVM.TagIds != null)
            {
                foreach (var tagId in productUpdateVM.TagIds)
                {
                    existProduct.ProductTags.Add(new ProductTag { TagId = tagId });
                }
            }

            existProduct.Name = productUpdateVM.Name;
            existProduct.Price = productUpdateVM.Price;
            existProduct.Description = productUpdateVM.Description ?? string.Empty;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
