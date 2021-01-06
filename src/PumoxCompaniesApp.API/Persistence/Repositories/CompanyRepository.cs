using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Repositories;
using PumoxCompaniesApp.API.Persistence.Contexts;
using PumoxCompaniesApp.API.Resources;

namespace PumoxCompaniesApp.API.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Company>> ListAsync()
        {

            return await _context.Companies.Include(p => p.Employees).ToListAsync();

        }

        public async Task<IEnumerable<Company>> ListCompositeKeyAsync(GetCompanyResourceQuery query)
        {
            if (query.EmployeeJobTitles == null || query.EmployeeJobTitles.Contains(null))
            {
                query.EmployeeJobTitles = new List<String>();
            }

            var companies = _context.Companies.Where(c => c.Name.Contains($"{query.KeyWord}"))
                .Include(e => e.Employees).ToListAsync();
            var result = await companies;
            if (result.Any())
            {
                return await ExecuteWhenCompanyFoundWithKeyword(query);
            }
            else
            {
                return await ExecuteWhenCompanyNotFoundWithKeyword(query);
            };
        }

        private async Task<IEnumerable<Company>> ExecuteWhenCompanyFoundWithKeyword(GetCompanyResourceQuery query)
        {
            var nextResults = _context.Companies.Include(e => e.Employees)
                       .Where(c =>
                        c.Employees.Any(e => (e.DateOfBirth.Date >= (query.EmployeeDateOfBirthFrom ?? DateTime.MinValue.Date)) &&
                        (e.DateOfBirth.Date <= (query.EmployeeDateOfBirthTo ?? DateTime.MaxValue.Date))) &&
                        (c.Employees.Any(e => query.EmployeeJobTitles.Contains(Enum.GetName(typeof(EJobTitle), e.JobTitle)) || !query.EmployeeJobTitles.Any())))
                       .ToListAsync();

            return await nextResults;
        }

        private async Task<IEnumerable<Company>> ExecuteWhenCompanyNotFoundWithKeyword(GetCompanyResourceQuery query)
        {
            var nextResults = _context.Companies.Include(e => e.Employees)
                    .Where(c => c.Employees.Any(e => e.FirstName.Contains($"{query.KeyWord}") || e.LastName.Contains($"{query.KeyWord}") || query.KeyWord == null) &&
                     c.Employees.Any(e => (e.DateOfBirth.Date >= (query.EmployeeDateOfBirthFrom ?? DateTime.MinValue.Date)) &&
                     (e.DateOfBirth.Date <= (query.EmployeeDateOfBirthTo ?? DateTime.MaxValue.Date))) &&
                     (c.Employees.Any(e => query.EmployeeJobTitles.Contains(Enum.GetName(typeof(EJobTitle), e.JobTitle)) || !query.EmployeeJobTitles.Any())))
                    .ToListAsync();
            return await nextResults;
        }

        public async Task AddAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task<Company> FindByIdAsync(long id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public void Update(Company company)
        {
            _context.Companies.Update(company);
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
        }
    }
}