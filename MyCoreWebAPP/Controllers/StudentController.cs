using Microsoft.AspNetCore.Mvc;
using MyCoreWebAPP.Models;
using MyCoreWebAPP.Services;

namespace MyCoreWebAPP.Controllers
{
    public class StudentController : Controller
        {
            public StudentDAL stDAL;

            public SchoolDBContext context;

            public StudentController(SchoolDBContext context)
            {
                this.context = context;
            }
            public IActionResult Index()
            {
            
                stDAL = new StudentDAL(context);
                List<Student> stdList= stDAL.GetAllStudents();
            
                return View(stdList);
            }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            //update database
            stDAL= new StudentDAL(context);
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
    }
}
