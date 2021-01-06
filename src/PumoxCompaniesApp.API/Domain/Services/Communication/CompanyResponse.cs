using PumoxCompaniesApp.API.Domain.Models;

namespace PumoxCompaniesApp.API.Domain.Services.Communication
{
    public class CompanyResponse : BaseResponse<Company>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="company">Saved category.</param>
        /// <returns>Response.</returns>
        public CompanyResponse(Company company) : base(company)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CompanyResponse(string message) : base(message)
        { }
    }
}