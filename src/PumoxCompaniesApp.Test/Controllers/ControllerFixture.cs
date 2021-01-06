using AutoMapper;
using Microsoft.OpenApi.Any;
using Moq;
using PumoxCompaniesApp.API.Controllers;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Services;
using PumoxCompaniesApp.API.Domain.Services.Communication;
using PumoxCompaniesApp.API.Identity.IntentityServices;
using PumoxCompaniesApp.API.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PumoxCompaniesApp.Test.Controllers
{
    public class ControllerFixture : IDisposable
    {

        public ControllerFixture()
        {
            var mockService = new Mock<ICompanyService>();
            mockService.Setup(service => service.ListAsync())
                .ReturnsAsync(new List<Company>(){new Company
                {
                    Name = "TestName",
                    Employees = new List<Employee>(),
                    EstablishmentYear = 2020
                }
                });

            mockService.Setup(service => service.ListCompaniesWithCompositeKey(It.IsAny<GetCompanyResourceQuery>()))
               .ReturnsAsync(new List<Company>(){new Company
                 {
                     Name = "TestName",
                     Employees = new List<Employee>(),
                     EstablishmentYear = 2020
                 }
               });

            mockService.Setup(service => service.SaveAsync(It.IsAny<Company>()))
               .ReturnsAsync(new CompanyResponse(new Company()));

            var usMock = new Mock<IUserService>();
            var mapperMock = new Mock<IMapper>();


            mapperMock.Setup(s => s.Map<IEnumerable<Company>, IEnumerable<CompanyOnGetResourceResp>>(It.IsAny<IEnumerable<Company>>())).Returns(new List<CompanyOnGetResourceResp>(){new CompanyOnGetResourceResp
                 {
                     Name = "TestName",
                     Employees = new List<EmployeeResource>(),
                     EstablishmentYear = 2020
                 }
            });
            mapperMock.Setup(s => s.Map<IEnumerable<CompanyOnGetResourceResp>, ListOfCompaniesResourceResp>(It.IsAny<IEnumerable<CompanyOnGetResourceResp>>())).Returns(new ListOfCompaniesResourceResp()
            {
                Results = new List<CompanyOnGetResourceResp>() {
                               new CompanyOnGetResourceResp() {
                               Name = "TestName",
                               Employees = new List<EmployeeResource>(),
                               EstablishmentYear = 2020
                         }
                     },
            }
            );

            mapperMock.Setup(s => s.Map<SaveAndUpdateCompanyResourceQuery, Company>(It.IsAny<SaveAndUpdateCompanyResourceQuery>())).Returns(new Company()
            {
                Id = 1034543534543453441,
                Name = "Pumox",
                EstablishmentYear = 1990
            }
         );
            mapperMock.Setup(s => s.Map<Company, CompanyOnPostResourceResp>(It.IsAny<Company>())).Returns(new CompanyOnPostResourceResp()
            {
                Id = 1034543534543453441
            }
         );
            controller = new CompaniesController(mockService.Object, mapperMock.Object, usMock.Object);
        }

        public void Dispose()
        {

        }
        public CompaniesController controller { get; private set; }
    }
}
