using HttpTriggers.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpTriggers.Services
{
    public class StudentService
    {
        public StudentService() { }
        public StudentService(SchoolDBContext dBContext)
        {
            Context = dBContext;
        }
        public SchoolDBContext Context;

        public int AddStudent(Student std)
        {
            Context.Students.Add(std);
            int result = Context.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student std)
        {
            Context.Students.Entry(std).State = EntityState.Modified;
            int result = Context.SaveChanges();
            return result;
        }

        public Student GetStudentById(int stdId)
        {
            return Context.Students.FirstOrDefault(s => s.Studentid == stdId);
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return Context.Students.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteStudentId(Student std)
        {
            //Context.Students.Remove(std);
            //      OR
            Context.Students.Entry(std).State = EntityState.Deleted;
            int result = Context.SaveChanges();
            return result;
        }


    }
}
