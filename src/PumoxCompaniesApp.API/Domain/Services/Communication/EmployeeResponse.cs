using PumoxCompaniesApp.API.Domain.Models;

namespace PumoxCompaniesApp.API.Domain.Services.Communication
{
    public class EmployeeResponse : BaseResponse<Employee>
    {
        public EmployeeResponse(Employee product) : base(product) { }

        public EmployeeResponse(string message) : base(message) { }
    }
}