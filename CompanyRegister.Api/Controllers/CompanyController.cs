using CompanyRegister.Domain.Models;
using CompanyRegister.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CompanyRegister.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _companyService.GetAllCompaniesAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _companyService.GetCompanyDetailsAsync(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCompany givencompany)
        {
            try
            {
                Company company = await _companyService.CreateCompanyAsync(givencompany);
                return Created("", company);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Update(int id, CreateCompany updateInformation)
        {
            try
            {
                await _companyService.UpdateCompanyAsync(id, updateInformation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Company Updated");
        }
        [HttpPut("AddOwner/{id}")]
        public async Task<IActionResult> AddOwner(int id, string ownerName, string ownerSocSecNumber)
        {
            try
            {
                await _companyService.AddOwnerToCompanyAsync(id, ownerName, ownerSocSecNumber);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("OwnerAdded");
        }

    }
}
