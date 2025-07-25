using IncludeVsDictionary.Benchmarks.IncludeVsDictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace IncludeVsDictionary.Benchmarks.IncludeVsDictionary;
public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EmployeeLevel>().HasData(
            new EmployeeLevel { Id = 1, Name = "Junior" },
            new EmployeeLevel { Id = 2, Name = "Middle" },
            new EmployeeLevel { Id = 3, Name = "Senior" },
            new EmployeeLevel { Id = 4, Name = "Lead" },
            new EmployeeLevel { Id = 5, Name = "Manager" });
    }
}