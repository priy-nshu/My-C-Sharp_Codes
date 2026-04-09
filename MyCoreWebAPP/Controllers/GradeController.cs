using Microsoft.AspNetCore.Mvc;
using MyCoreWebAPP.Models;
using MyCoreWebAPP.Services;

namespace MyCoreWebAPP.Controllers
{
    public class GradeController : Controller
    {
        public IGradeService grdService;

        public GradeController(IGradeService grdService)
        {
            this.grdService = grdService;
        }

        public async Task<IActionResult> Index()
        {
            List<Grade> grdList = await grdService.GetAllGrades();
           
            return View(grdList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Grade grd)
        {
            //update database

            if (!ModelState.IsValid)
            {
                //The way to send error is by using ViewBag or ViewData
                //OR use Strongly typed argument like BELOW 
                ViewBag.ErrorMessage = "Please correct the errors";
                return View(grd);
            }
            int result = await grdService.AddGrade(grd);

            return RedirectToAction("Index");
        }
    }
}
