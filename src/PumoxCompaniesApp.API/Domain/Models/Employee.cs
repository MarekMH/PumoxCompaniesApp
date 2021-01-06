using System;
using System.Collections.Generic;

namespace PumoxCompaniesApp.API.Domain.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EJobTitle JobTitle { get; set; }
        public Company Company { get; set; }
        public long CompanyId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   FirstName == employee.FirstName &&
                   LastName == employee.LastName &&
                   DateOfBirth == employee.DateOfBirth &&
                   JobTitle == employee.JobTitle;
        }
    }
}