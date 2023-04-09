using CompanyManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyManager.Repository.Configuration;

public static class InitialDataConfiguration
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        SeedCompanies(modelBuilder);
        SeedEmployees(modelBuilder);
    }

    private static void SeedCompanies(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "IT_Solutions Ltd",
                Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                Country = "USA"
            },
            new Company
            {
                Id = 2,
                Name = "Admin_Solutions Ltd",
                Address = "312 Forest Avenue, BF 923",
                Country = "USA"
            }
        );
    }

    private static void SeedEmployees(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Sam Raiden",
                Age = 26,
                Position = "Software developer",
                CompanyId = 1
            },
            new Employee
            {
                Id = 2,
                Name = "Jana McLeaf",
                Age = 30,
                Position = "Software developer",
                CompanyId = 1
            },
            new Employee
            {
                Id = 3,
                Name = "Kane Miller",
                Age = 35,
                Position = "Administrator",
                CompanyId = 2
            }
        );
    }
}