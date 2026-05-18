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
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories
                .Where(c => !c.IsDeleted)
                .ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);

            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category does not exist!");
                return View(productCreateVM);
            }

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
