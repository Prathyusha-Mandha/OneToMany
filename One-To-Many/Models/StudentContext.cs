using Microsoft.EntityFrameworkCore;

namespace One_To_Many.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=Prathyusha;database=One-To-Many;integrated security=True;trustservercertificate=True;");
        }
    }
}
