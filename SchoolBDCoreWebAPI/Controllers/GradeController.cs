using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolDBCodeFirstApp.Models;
using SchoolDBCoreWebAPI.Models;
using SchoolDBCoreWebAPI.Services;

namespace SchoolDBCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
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
    }
}
