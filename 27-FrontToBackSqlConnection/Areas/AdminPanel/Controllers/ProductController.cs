using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Product;
using _27_FrontToBackSqlConnection.Db;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment? env)
        {
            _context = context;
            _env = env;
        }
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

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories
                .Where(c => !c.IsDeleted)
                .ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);

            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category does not exist!");
                return View(productCreateVM);
            }

            if (productCreateVM.TagIds != null && productCreateVM.TagIds.Any())
            {
                foreach (int tagId in productCreateVM.TagIds)
                {
                    bool tagExistsInDb = productCreateVM.Tags.Any(t => t.Id == tagId);

                    if (!tagExistsInDb)
                    {
                        ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "One or more selected tags do not exist!");
                        return View(productCreateVM);
                    }
                }
            }

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
                Description = productCreateVM.Description
            };

            if (productCreateVM.TagIds != null)
            {
                foreach (int tagId in productCreateVM.TagIds)
                {
                    product.ProductTags.Add(new ProductTag { TagId = tagId });
                }
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? existProduct = await _context.Products.Include(p => p.ProductTags)
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
                Tags = await _context.Tags.Where(c => !c.IsDeleted).ToListAsync()
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            productUpdateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            if (id == null || id < 1) return BadRequest();
            if (!ModelState.IsValid) return View(productUpdateVM);

            Product? existProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (existProduct == null) return NotFound();

            bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductUpdateVM.CategoryId), "Category does not exist!");
                return View(productUpdateVM);
            }

            existProduct.Name = productUpdateVM.Name;
            existProduct.Price = productUpdateVM.Price;
            existProduct.Description = productUpdateVM.Description;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
