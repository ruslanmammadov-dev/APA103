using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{

    public class HomeController : Controller
    {
        public  IActionResult Index()
        {
            //var student = JsonResult(new { Id = 1, name = "Jack", Surname = "Eden" });
            //return student;
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
