//todo: delete newtonsoft if working

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PumoxCompaniesApp.API.Domain.Models;
using System;

namespace PumoxCompaniesApp.API.Resources
{
    public class EmployeeResource
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string JobTitle { get; set; }
    }
}