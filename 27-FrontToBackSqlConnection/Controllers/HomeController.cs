using _27_FrontToBackSqlConnection.Db;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Slider> sliders = _context.Sliders
            .Where(s => !s.IsDeleted)
            .OrderBy(s => s.Order)
            .Take(2)
            .ToList();

        List<Product> products = _context.Products
            .Include(p => p.Category)
            .Include(p => p.ProductImages)
            .Where(p => !p.IsDeleted)
            .ToList();

        HomeVM homeVM = new HomeVM()
        {
            Sliders = sliders,
            Products = products
        };

        return View(homeVM);
    }
}