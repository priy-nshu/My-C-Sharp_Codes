using Microsoft.EntityFrameworkCore;

namespace MyCoreWebAPP.Models
{
    public class SchoolDBContext : DbContext
    {

        public SchoolDBContext()
        {
        }
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        {

        }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* if (!optionsBuilder.IsConfigured)
                 //optionsBuilder.UseSqlServer("server=EC2AMAZ-EHR6SVV; Database=SchoolDb; Integrated Security=True; Trusted_Connection=True ;TrustServerCertificate=True;");
                 optionsBuilder.UseSqlServer(_ConStr);*/
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(entity => {
                entity.HasKey(e => e.GradeId).HasName("PK__Grade");
                entity.ToTable("grades", "School");
            });


            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Studentid).HasName("PK__Student");

                entity.ToTable("students", "School");
                entity.HasOne(s => s.grade).WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__grades__students");

            });
        }
    }
}
