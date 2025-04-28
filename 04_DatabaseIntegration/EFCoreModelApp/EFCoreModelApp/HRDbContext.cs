using Microsoft.EntityFrameworkCore;

using EFCoreModelApp;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCoreModelApp
{
    public class HRDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=HRApp.db")
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
                );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity
                    .HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.DepartmentID);
            });

            _ = modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, Name = "HR", Employees = new List<Employee>() },
                new Department { DepartmentID = 2, Name = "Engineering", Employees = new List<Employee>() }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Aiko",
                    LastName = "Tanaka",
                    HireDate = DateTime.Now,
                    DepartmentID = 1
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Zainab",
                    LastName = "Al-Farsi",
                    HireDate = DateTime.Now,
                    DepartmentID = 2
                }
            );
        }
    }
}