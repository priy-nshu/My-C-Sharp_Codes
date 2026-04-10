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

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            Grade grade = null;
            try
            {
                grade = await grdService.GetGradeById(Id);

                if (grade == null)
                {
                    return NotFound(); 
                }
            }
            catch (HttpRequestException ex)
            {
                return View("error");
            }

            return View(grade);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int GradeId, Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return View(grade);
            }
            
                int result= await grdService.UpdateGrade(grade.GradeId, grade); 
                return RedirectToAction("Index");        
        }

        [HttpGet]
        public async Task<IActionResult> LoadGrades()
        {
            try
            {
                List<Grade> grades = await grdService.GetAllGrades();
                return PartialView("LoadGrades", grades);
            }
            catch(HttpRequestException ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            Grade grade = null;
            try
            {
                grade = await grdService.GetGradeById(Id);
                if (grade == null)
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException ex)
            {
                return View("Error");
            }
            return View(grade);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int GradeId)
        {
            try
            {
                int result = await grdService.DeleteGrade(GradeId);
                if (result == 0)
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException ex)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
