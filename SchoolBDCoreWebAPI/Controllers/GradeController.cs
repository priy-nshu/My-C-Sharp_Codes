using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDBCodeFirstApp.Models;
using SchoolDBCoreWebAPI.Models;
using SchoolDBCoreWebAPI.Services;

namespace SchoolDBCoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        public GradeDAL grDAL;
        public SchoolDBContext context;
        

        public GradeController(SchoolDBContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public ActionResult<List<Grade>> GetAllGrades()
        {
            grDAL = new GradeDAL(context);
            return grDAL.GetAllGrades();
        }

        [HttpGet("{gradeId}")]
        public ActionResult<Grade> GetGradeById(int gradeId)
        {
            grDAL = new GradeDAL(context);
            return grDAL.GetGradeById(gradeId);
        }

        [HttpPost]
        public IActionResult AddGrade(Grade grade)
        {
            grDAL = new GradeDAL(context);
            grDAL.AddGrade(grade);
            return Ok(new { message = "Successfully Added" });
        }

        [HttpPut]
        public IActionResult UpdateGrade(Grade grade)
        {
            grDAL = new GradeDAL(context);
            grDAL.UpdateGrade(grade);
            return Ok(new { message = "Successfully Updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGrade(int id)
        {
            grDAL = new GradeDAL(context);
            grDAL.DeleteGrade(id);
            return Ok(new { message = "Successfully Deleted" });
        }
    }
}

