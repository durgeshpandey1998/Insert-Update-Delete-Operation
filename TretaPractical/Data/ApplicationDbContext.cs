using Microsoft.EntityFrameworkCore;
using TretaPractical.Models;

namespace TretaPractical.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectAssign> ProjectAssigns { get; set; }
    }
}
