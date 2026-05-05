using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var items = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 15000 },
            new Product { Id = 2, Name = "Mouse", Price = 500 }
        };

            ViewBag.Message = "Xoş geldiniz!";

            var viewModel = new ProductListViewModel
            {
                Products = items,
                CategoryName = "Elektronika"
            };

            return View(viewModel);
        }
    }
}
