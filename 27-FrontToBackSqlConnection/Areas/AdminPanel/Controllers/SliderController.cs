using _27_FrontToBackSqlConnection.Db;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Extension;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Slider;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment? env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .ToListAsync();

            return View(sliders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM slider)
        {
            if (slider.Photo == null) return View();

            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Səhv format");
                return View();
            }

            if (!slider.Photo.CheckFileSize(FileSizes.MB, 2))
            {
                ModelState.AddModelError("Photo", "Maksimum 2MB");
                return View();
            }

            Slider slider1 = new()
            {
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Description = slider.Description,
                Order = slider.Order,
                Image = await slider.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images")
            };

            await _context.Sliders.AddAsync(slider1);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return NotFound();

            slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new()
            {
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Description = slider.Description,
                Order = slider.Order,
                Image = slider.Image,
            };

            return View(sliderUpdateVM);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (slider == null) return NotFound();

            return View(slider);
        }
    }
}
