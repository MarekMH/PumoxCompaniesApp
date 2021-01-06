using System.Collections.Generic;

namespace PumoxCompaniesApp.API.Resources
{
    public class CompanyOnGetResourceResp
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public IList<EmployeeResource> Employees { get; set; } = new List<EmployeeResource>();
    }
}