using PumoxCompaniesApp.API.Domain.Models;
using System.Collections.Generic;

namespace PumoxCompaniesApp.API.Resources
{
    public class CompanyOnPutResourceResp
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public IList<EmployeeResource> Employees { get; set; } = new List<EmployeeResource>();
    }
}