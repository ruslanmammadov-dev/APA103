using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _27_FrontToBackSqlConnection.Db;
using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories
                .Include(c=>c.Products)
                .Where(c => !c.IsDeleted)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            bool existCategory = await _context.Categories
                .AnyAsync(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());

            if (existCategory)
            {
                ModelState.AddModelError("Name", "Bu adda kategoriya var!");
                return View(category);
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}