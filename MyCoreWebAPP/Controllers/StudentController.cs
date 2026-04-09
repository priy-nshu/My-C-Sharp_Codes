using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCoreWebAPP.Models;
using MyCoreWebAPP.Services;

namespace MyCoreWebAPP.Controllers
{
    public class StudentController : Controller
    {
        public StudentDAL stDAL;
        public IGradeService gradeService;
        public SchoolDBContext context;

        public StudentController(SchoolDBContext context,IGradeService grdService)
        {
            this.gradeService = grdService;
            this.context = context;
        }
        public IActionResult Index()
        {

            stDAL = new StudentDAL(context);
            List<Student> stdList = stDAL.GetAllStudents();

            return View(stdList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<Grade> grades = await gradeService.GetAllGrades();
            var myList = (from g in grades
                          select new SelectListItem()
                          {
                              Value = g.GradeId.ToString(),
                              Text =$"{g.Section} - {g.Description}"
                          }).ToList();
            //to show Select as First Item
            myList.Insert(0, new SelectListItem { Value = string.Empty, Text = "Select" });

            ViewBag.Grades = myList;
            return View();
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult Create(Student student)
        {
            //update database
            stDAL= new StudentDAL(context);
            //if (!ModelState.IsValid)
            //{
            //    //The way to send error is by using ViewBag or ViewData
            //    //OR use Strongly typed argument like BELOW 
            //    return View(student);
            //}
            int result =stDAL.AddStudent(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            stDAL=new StudentDAL(context);
            Student std = stDAL.GetStudentById(Id);
            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(int Id,Student student)
        {
            stDAL = new StudentDAL(context);
            int result=stDAL.UpdateStudent(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            stDAL = new StudentDAL(context);
            Student std = stDAL.GetStudentById(Id);
            return View(std);
        }

        [HttpGet]
        public IActionResult Delete(int Id) {
            stDAL = new StudentDAL(context);
            if (Id == null) return NotFound();

            Student std = stDAL.GetStudentById(Id);            
            return View(std);
        }
        [HttpPost]
        public IActionResult Delete(int Id, Student student) { 
            stDAL =new StudentDAL(context);
            int result = stDAL.DeleteStudentId(student);

            return RedirectToAction("Index");
        }
    }
}
