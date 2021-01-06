using System;
using System.Collections.Generic;

namespace PumoxCompaniesApp.API.Domain.Models.Queries
{
    public class CompanyQuery : Query
    {
        public string? KeyWord { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }

        public DateTime? EmployeeDateOfBirthTo { get; set; }

        public IList<EJobTitle>? EmployeeJobTitles { get; set; } = new List<EJobTitle>();

        public CompanyQuery(string keyWord, DateTime employeeDateOfBirthFrom, DateTime employeeDateOfBirthTo, IList<EJobTitle> employeeJobTitles, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            KeyWord = keyWord;
            EmployeeDateOfBirthFrom = employeeDateOfBirthFrom;
            EmployeeDateOfBirthTo = employeeDateOfBirthTo;
            EmployeeJobTitles = employeeJobTitles;
        }
    }
}
