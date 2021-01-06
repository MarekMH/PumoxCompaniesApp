/*using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Models.Queries;
using PumoxCompaniesApp.API.Domain.Repositories;
using PumoxCompaniesApp.API.Domain.Services;
using PumoxCompaniesApp.API.Domain.Services.Communication;
using PumoxCompaniesApp.API.Infrastructure;

namespace PumoxCompaniesApp.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public EmployeeService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<QueryResult<Employee>> CompanySearchAsync(CompanyQuery query)
        {
            // Here I list the query result from cache if they exist, but now the data can vary according to the category ID, page and amount of
            // items per page. I have to compose a cache to avoid returning wrong data.
            string cacheKey = GetCacheKeyForProductsQuery(query);
            
            var products = await _cache.GetOrCreateAsync(cacheKey, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _employeeRepository.CompanySearchAsync(query);
            });

            return products;
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                *//*
                 Notice here we have to check if the category ID is valid before adding the product, to avoid errors.
                 You can create a method into the CategoryService class to return the category and inject the service here if you prefer, but 
                 it doesn't matter given the API scope.
                *//*
                var existingCompany = await _companyRepository.FindByIdAsync(employee.CompanyId);
                if (existingCompany == null)
                    return new EmployeeResponse("Invalid category.");

                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EmployeeResponse($"An error occurred when saving the product: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(long id, Employee product)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Product not found.");

            var existingCompany = await _companyRepository.FindByIdAsync(product.CompanyId);
            if (existingCompany == null)
                return new EmployeeResponse("Invalid category.");

            existingEmployee.FirstName = product.FirstName;
            existingEmployee.LastName = product.LastName;
            existingEmployee.JobTitle = product.JobTitle;
            existingEmployee.DateOfBirth = product.DateOfBirth;
           
            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EmployeeResponse($"An error occurred when updating the product: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> DeleteAsync(long id)
        {
            var existingProduct = await _employeeRepository.FindByIdAsync(id);

            if (existingProduct == null)
                return new EmployeeResponse("Product not found.");

            try
            {
                _employeeRepository.Remove(existingProduct);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingProduct);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EmployeeResponse($"An error occurred when deleting the product: {ex.Message}");
            }
        }

        private string GetCacheKeyForProductsQuery(CompanyQuery query)
        {
            string key = CacheKeys.EmployeesList.ToString();
            
            if (query.CompanyId.HasValue && query.CompanyId > 0)
            {
                key = string.Concat(key, "_", query.CompanyId.Value);
            }

            key = string.Concat(key, "_", query.Page, "_", query.itemsPerPage);
            return key;
        }
    }
}*/