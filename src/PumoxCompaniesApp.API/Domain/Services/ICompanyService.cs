using System.Collections.Generic;
using System.Threading.Tasks;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Services.Communication;
using PumoxCompaniesApp.API.Resources;

namespace PumoxCompaniesApp.API.Domain.Services
{
    public interface ICompanyService
    {
         Task<IEnumerable<Company>> ListCompaniesWithCompositeKey(GetCompanyResourceQuery query);
         Task<CompanyResponse> SaveAsync(Company category);
         Task<CompanyResponse> UpdateAsync(long id, Company category);
         Task<CompanyResponse> DeleteAsync(long id);
         Task<IEnumerable<Company>> ListAsync();
    }
}