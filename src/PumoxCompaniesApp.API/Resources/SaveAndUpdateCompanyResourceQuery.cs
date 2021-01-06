using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PumoxCompaniesApp.API.Resources
{
    public class SaveAndUpdateCompanyResourceQuery
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1800, 2025)]
        public int EstablishmentYear { get; set; }

        [Required]
        public IList<EmployeeResource> Employees { get; set; } = new List<EmployeeResource>();
    }
}