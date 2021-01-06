using System.Collections.Generic;

namespace PumoxCompaniesApp.API.Domain.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        //here I'm using List for better AutoMapping conversion (it provides me of method ForEach)
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public override bool Equals(object obj)
        {
            return obj is Company company &&
                   Name == company.Name &&
                   EstablishmentYear == company.EstablishmentYear &&
                   EqualityComparer<List<Employee>>.Default.Equals(Employees, company.Employees);
        }
    }
}