using System.ComponentModel.DataAnnotations;

namespace MyCoreWebAPP.Models
{
    public class Student
    {
        [Key]
        public int Studentid { get; set; }
        public string Name { get; set; } = null!;
        public string RollNumber { get; set; } = null!;

        //these two below make the foriegn key 
        public int GradeId { get; set; }
        public virtual Grade grade { get; set; }

    }
}
