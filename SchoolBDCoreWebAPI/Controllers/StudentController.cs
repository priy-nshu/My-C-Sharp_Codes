using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDBCodeFirstApp.Models;
using SchoolDBCoreWebAPI.Models;
using SchoolDBCoreWebAPI.Services;

namespace SchoolDBCoreWebAPI.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentDAL stDAL;

        public SchoolDBContext context;

        public StudentController(SchoolDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            stDAL = new StudentDAL(context);
            return stDAL.GetAllStudents();
        }

        [HttpGet("{stdId}")]
        public ActionResult<Student> GetStudentbyId(int stdId)
        {
            stDAL = new StudentDAL(context);
            return stDAL.GetStudentById(stdId);
        }

        [HttpPost]
        public ActionResult<int> AddStudents(Student std)
        {
            stDAL = new StudentDAL(context);
            return stDAL.AddStudent(std);
        }
    }
}
