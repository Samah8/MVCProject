using Microsoft.EntityFrameworkCore;
namespace Lab2.Models
{
    public class LabDB:DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=_Lab1;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}
