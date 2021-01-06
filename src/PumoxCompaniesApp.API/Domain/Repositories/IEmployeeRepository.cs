using PumoxCompaniesApp.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}
