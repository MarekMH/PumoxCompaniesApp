using Microsoft.AspNetCore.Mvc;
using PumoxCompaniesApp.API.Resources;
using Xunit;

namespace PumoxCompaniesApp.Test.Controllers
{
    public class CompaniesControllerTest : IClassFixture<ControllerFixture>
    {

        ControllerFixture fixture;
        public CompaniesControllerTest(ControllerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Get_WhenCalledToListAllCompanies_ReturnsOkResult()
        {
            // Arrange
            //the data is arranged in ControllerFixture class
            // Act
            var okResult = fixture.controller.CompanySearchAsync();
            // Assert
            Assert.IsAssignableFrom<ListOfCompaniesResourceResp>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalledToSearchForCompany_ReturnsOkResult()
        {
            // Arrange
            GetCompanyResourceQuery query = new GetCompanyResourceQuery
            {
                KeyWord = "HEM",
                EmployeeDateOfBirthFrom = null,
                EmployeeDateOfBirthTo = null,
                EmployeeJobTitles = null
            };

            // Act
            var okResult = fixture.controller.CompanySearchAsync(query);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_CreateNewCompany_ReturnsOkResult()
        {
            // Arrange
            SaveAndUpdateCompanyResourceQuery query = new SaveAndUpdateCompanyResourceQuery
            {
                Name = "Arribatec",
                EstablishmentYear = 2017
            };

            // Act
            var okResult = fixture.controller.CompanyCreateAsync(query);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        //w naszym przypadku walidacja może być sprawdzona tylko w testach integracyjnych

        /*[Fact]
        public void Post_CreateNewCompany_ThrowBadRequest()
        {
            // Arrange
            SaveAndUpdateCompanyResourceQuery query = new SaveAndUpdateCompanyResourceQuery
            {
                Name = "Arribatec",
            };

            // Act
            var badResult = fixture.controller.CompanyCreateAsync(query);
            // Assert
            var badRequestResult = Assert.IsType<Task<BadRequestObjectResult>>(badResult);
            // Assert.IsType<SerializableError>(badRequestResult.Value);
        }*/
    }
}
