using System.Collections.Generic;

namespace PumoxCompaniesApp.API.Domain.Models.Queries
{
    public class QueryResult<T>
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public IList<Employee> Employees { get; set; } = new List<Employee>();
    }
}