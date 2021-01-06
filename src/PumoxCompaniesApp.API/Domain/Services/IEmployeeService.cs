using System.Threading.Tasks;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Models.Queries;
using PumoxCompaniesApp.API.Domain.Services.Communication;

namespace PumoxCompaniesApp.API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<QueryResult<Employee>> ListAsync(CompanyQuery query);
        Task<EmployeeResponse> SaveAsync(Employee product);
        Task<EmployeeResponse> UpdateAsync(long id, Employee product);
        Task<EmployeeResponse> DeleteAsync(long id);
    }
}