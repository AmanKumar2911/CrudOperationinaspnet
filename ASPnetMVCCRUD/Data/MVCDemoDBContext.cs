using ASPnetMVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPnetMVCCRUD.Data
{
    public class MVCDemoDBContext : DbContext
    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)

        {
            base.OnModelCreating(builder);

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }  
        
    }
}
