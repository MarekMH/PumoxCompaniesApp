using AutoMapper;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Models.Queries;
using PumoxCompaniesApp.API.Extensions;
using PumoxCompaniesApp.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PumoxCompaniesApp.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Company, CompanyOnPutResourceResp>();
            CreateMap<Company, CompanyOnPostResourceResp>();
            CreateMap<Company, CompanyOnGetResourceResp>();
            CreateMap<IEnumerable<CompanyOnGetResourceResp>, ListOfCompaniesResourceResp>()
               .ConvertUsing(src => new ListOfCompaniesResourceResp { Results = (IList<CompanyOnGetResourceResp>)src });

            CreateMap<Employee, EmployeeResource>()
                .ForMember(src => src.JobTitle,
                           opt => opt.MapFrom(src => Enum.GetName(typeof(EJobTitle), src.JobTitle)));
        }
    }
}