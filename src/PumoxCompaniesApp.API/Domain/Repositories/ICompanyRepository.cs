using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Models.Queries;
using PumoxCompaniesApp.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> ListCompositeKeyAsync(GetCompanyResourceQuery query);
        Task AddAsync(Company company);
        Task<Company> FindByIdAsync(long id);
        void Update(Company company);
        void Remove(Company company);
        Task<IEnumerable<Company>> ListAsync();
    }
}
