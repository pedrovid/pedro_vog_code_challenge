using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API.Context
{
    public class VogDbContext : DbContext
    {
        public VogDbContext(DbContextOptions<VogDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(p => p.Employees)
                .WithOne();

            modelBuilder.Entity<Department>()
                .Navigation(b => b.Employees)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
