using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Models.Queries;
using PumoxCompaniesApp.API.Domain.Repositories;
using PumoxCompaniesApp.API.Domain.Services;
using PumoxCompaniesApp.API.Domain.Services.Communication;
using PumoxCompaniesApp.API.Infrastructure;
using PumoxCompaniesApp.API.Resources;

namespace PumoxCompaniesApp.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public CompanyService(ICompanyRepository companyRepository, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _companyRepository = companyRepository;
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {

            var companies = await _cache.GetOrCreateAsync(CacheKeys.CompaniesList, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _companyRepository.ListAsync();
            });

            return companies;
        }


        public async Task<IEnumerable<Company>> ListCompaniesWithCompositeKey(GetCompanyResourceQuery query)
        {
            var companies = _companyRepository.ListCompositeKeyAsync(query);
            return await companies;
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                foreach (Employee emp in company.Employees)
                {
                    await _employeeRepository.AddAsync(emp);
                }
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch (Exception ex)
            {
                return new CompanyResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(long id, Company company)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found.");

            foreach (Employee emp in company.Employees)
            {
                foreach (Employee existingEmp in existingCompany.Employees)
                {
                    if (emp.Equals(existingEmp))
                    {
                        emp.Id = id;
                        emp.CompanyId = existingCompany.Id;
                        emp.Company = existingCompany;
                        _employeeRepository.Update(emp);
                    }
                }
                if (emp.Id != id)
                {
                    await _employeeRepository.AddAsync(emp);
                }
            }
            _companyRepository.Update(company);

            try
            {
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CompanyResponse($"An error occurred when updating the company: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> DeleteAsync(long id)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company not found.");

            try
            {
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CompanyResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

    }
}
