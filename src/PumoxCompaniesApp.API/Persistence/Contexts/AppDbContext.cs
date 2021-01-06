using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Identity.Model;
using System;

namespace PumoxCompaniesApp.API.Persistence.Contexts
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>().ToTable("Companies");
            builder.Entity<Company>().HasKey(p => p.Id);
            builder.Entity<Company>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Company>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Company>().Property(p => p.EstablishmentYear).IsRequired().HasMaxLength(4);
            builder.Entity<Company>().HasMany(p => p.Employees).WithOne(p => p.Company).HasForeignKey(p => p.CompanyId);

            builder.Entity<Company>().HasData
            (
                new Company { Id = 1034543534543453441, Name = "Pumox", EstablishmentYear = 1990 },
                new Company { Id = 1034543545645653441, Name = "HEM", EstablishmentYear = 2018 },
                new Company { Id = 1034543454545667841, Name = "Zybi", EstablishmentYear = 1995 },
                new Company { Id = 1034543454345667841, Name = "RCK", EstablishmentYear = 2000 },
                new Company { Id = 1032343454545667841, Name = "Constravia", EstablishmentYear = 2003 }
            );

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(p => p.Id);
            builder.Entity<Employee>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employee>().Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            builder.Entity<Employee>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Employee>().Property(p => p.DateOfBirth).IsRequired().HasMaxLength(50);
            builder.Entity<Employee>().Property(p => p.JobTitle).IsRequired();
            builder.Entity<Employee>().Property(p => p.CompanyId).IsRequired();

            builder.Entity<Employee>().HasData
            (
                new Employee
                {
                    Id = 1034543532345453441,
                    FirstName = "Marek",
                    LastName = "Hetman",
                    DateOfBirth = new DateTime(1992, 8, 9),
                    JobTitle = EJobTitle.Developer,
                    CompanyId = 1034543545645653441
                },
                new Employee
                {
                    Id = 1034543567893453441,
                    FirstName = "Andrzej",
                    LastName = "Ford",
                    DateOfBirth = new DateTime(1998, 8, 9),
                    JobTitle = EJobTitle.Administrator,
                    CompanyId = 1034543545645653441
                },
                  new Employee
                  {
                      Id = 1034543556783453441,
                      FirstName = "Grzegorz",
                      LastName = "Lagaciuk",
                      DateOfBirth = new DateTime(1992, 8, 9),
                      JobTitle = EJobTitle.Developer,
                      CompanyId = 1034543454345667841
                  },
                   new Employee
                   {
                       Id = 1034543562345453441,
                       FirstName = "Martin",
                       LastName = "George",
                       DateOfBirth = new DateTime(1965, 8, 9),
                       JobTitle = EJobTitle.Administrator,
                       CompanyId = 1034543454345667841
                   }
            );
        }
    }
}