using Microsoft.AspNetCore.Mvc;
using MyCoreWebAPP.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MyCoreWebAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ViewBag.Admin = "admin";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ContentResult MyContent()
        {
            //return Content("<script> alert('Hi! I am Priyanshu')</script", "text/html");
            return Content("I am ContentResult");
        }

        public FileResult MyFile()
        {
            return File("~/Files/text.txt", "text/plain");
        }

        public JsonResult MyJson() 
            {
                var jsonData = new
                {
                    Name = "Pappaya",
                    Id = 4,
                    DateOfBirth = new DateTime(1999,03,29)
                };
            return Json(jsonData);
            }

        public RedirectResult MyRedirect()
        {
            return Redirect("https://www.msn.com");
        }
        public RedirectToRouteResult MyRedirectToRoute()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        public RedirectToActionResult MyRedirectToAction()
        {
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
