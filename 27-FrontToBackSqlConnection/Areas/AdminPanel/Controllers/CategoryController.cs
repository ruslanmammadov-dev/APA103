using _27_FrontToBackSqlConnection.Db;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Moderator")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,Moderator,Member")]
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories
                .Include(c=>c.Products)
                .Where(c => !c.IsDeleted)
                .ToListAsync();

            return View(categories);
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Moderator")]
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
        [Authorize(Roles = "Admin,Moderator")]
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (category == null) return NotFound();

            return View(category);
        }
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();

            if (!ModelState.IsValid) return View(category);

            bool isExist = await _context.Categories
                .AnyAsync(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower() && c.Id != id);

            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda kategoriya var!");
                return View(category);
            }

            Category? existCategory = await _context.Categories.FindAsync(id);
            if (existCategory == null) return NotFound();

            existCategory.Name = category.Name.Trim();

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Category? existCategory = await _context.Categories
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existCategory is null) return NotFound();

            _context.Categories.Remove(existCategory);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            var category = await _context.Categories
                .Include(c => c.Products.Where(p => !p.IsDeleted))
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (category == null) return NotFound();

            return View(category);
        }
    }
}