using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PumoxCompaniesApp.API.Domain.Models;
using PumoxCompaniesApp.API.Domain.Services;
using PumoxCompaniesApp.API.Identity.IntentityServices;
using PumoxCompaniesApp.API.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumoxCompaniesApp.API.Controllers
{
    [Route("/company")]
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class CompaniesController : Controller
    {
        /*private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;*/
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _companyService = companyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all companies.
        /// </summary>
        /// <returns>List os categories.</returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(ListOfCompaniesResourceResp), 200)]
        public async Task<ListOfCompaniesResourceResp> CompanySearchAsync()
        {
            var companies = await _companyService.ListAsync();
            var mappedToList = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyOnGetResourceResp>>(companies);
            var mappedToResponseModel = _mapper.Map<IEnumerable<CompanyOnGetResourceResp>, ListOfCompaniesResourceResp>(mappedToList);

            return mappedToResponseModel;
        }

        /// <summary>
        /// Lists all companies.
        /// </summary>
        /// <returns>List os categories.</returns>


        /// <summary>
        /// Shows company within given range.
        /// </summary>
        /// <returns>List os companies.</returns>
        [HttpPost("search")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ListOfCompaniesResourceResp), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> CompanySearchAsync([FromBody] GetCompanyResourceQuery query)
        {
            if (query.EmployeeDateOfBirthFrom > query.EmployeeDateOfBirthTo)
            {
                return UnprocessableEntity(new ErrorResource("Date of birth - from cannot be bigger than date of birth - to"));
            }

            IEnumerable<Company> companies = await _companyService.ListCompaniesWithCompositeKey(query);
            if (!companies.Any())
            {
                return Ok("Query executed. No companies found...");
            }

            var mappedToList = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyOnGetResourceResp>>(companies);
            var mappedToResponseModel = _mapper.Map<IEnumerable<CompanyOnGetResourceResp>, ListOfCompaniesResourceResp>(mappedToList);

            return Ok(mappedToResponseModel);
        }

        /// <summary>
        /// Saves a new company.
        /// </summary>
        /// <param name="resource">Company data.</param>
        /// <returns>Response for the request.</returns>
        [Authorize]
        [HttpPost("create")]
        [ProducesResponseType(typeof(CompanyOnPostResourceResp), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> CompanyCreateAsync([FromBody] SaveAndUpdateCompanyResourceQuery resource)
        {

            var company = _mapper.Map<SaveAndUpdateCompanyResourceQuery, Company>(resource);
            var result = await _companyService.SaveAsync(company);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var companyResource = _mapper.Map<Company, CompanyOnPostResourceResp>(result.Resource);
            return Ok(companyResource);
        }

        /// <summary>
        /// Updates an existing company according to an identifier.
        /// </summary>
        /// <param name="id">Company identifier.</param>
        /// <param name="resource">Updated company data.</param>
        /// <returns>Response for the request.</returns>
        [Authorize]
        [HttpPut("update/{id:long}")]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> CompanyUpdateAsync(long id, [FromBody] SaveAndUpdateCompanyResourceQuery resource)
        {
            var company = _mapper.Map<SaveAndUpdateCompanyResourceQuery, Company>(resource);
            var result = await _companyService.UpdateAsync(id, company);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            return Ok();
        }

        /// <summary>
        /// Deletes a given company according to an identifier.
        /// </summary>
        /// <param name="id">Company identifier.</param>
        /// <returns>Response for the request.</returns>
        [Authorize]
        [HttpDelete("delete/{id:long}")]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> CompanyDeleteAsync(long id)
        {
            var result = await _companyService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            return Ok($"Company with id: {id} was deleted succesfully!");
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] IdentityResource model)
        {
            var user = await _userService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

    }
}