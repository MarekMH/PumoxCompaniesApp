using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Resources
{
    public class GetCompanyResourceQuery
    {

        [MaxLength(50)]
        public string KeyWord { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EmployeeDateOfBirthFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EmployeeDateOfBirthTo { get; set; }


        public IList<string> EmployeeJobTitles { get; set; } = new List<string>();

    }
}
