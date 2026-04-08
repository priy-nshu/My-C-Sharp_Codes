using System.ComponentModel.DataAnnotations;

namespace MyCoreWebAPP.Models
{
        public class Grade
        {
            [Key]
            public int GradeId { get; set; }

            //[StringLength(25)]
            //[Column("grade_name",TypeName ="VarChar")]
            //public string? GradeName { get; set; } //Removed using update-database "ISV1" to migrate back to this <--

            public string Section { get; set; } = null!;
            public string? Description { get; set; }

            public ICollection<Student> Students { get; set; }

        }
    }
