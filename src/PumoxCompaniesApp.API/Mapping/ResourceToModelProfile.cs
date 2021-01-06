using AutoMapper;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Models.Queries;
using PumoxCompaniesApp.API.Resources;
using System;

namespace PumoxCompaniesApp.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAndUpdateCompanyResourceQuery, Company>();
            CreateMap<EmployeeResource, Employee>().ForMember(src => src.JobTitle,
                           opt => opt.MapFrom(src => Enum.Parse(typeof(EJobTitle), src.JobTitle, true)));
        }
    }
}