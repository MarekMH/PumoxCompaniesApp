using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Repositories;
using PumoxCompaniesApp.API.Persistence.Contexts;
using System;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }

}
