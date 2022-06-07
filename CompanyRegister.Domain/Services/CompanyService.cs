using CompanyRegister.Domain.Dtos;
using CompanyRegister.Domain.Interfaces;
using CompanyRegister.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Company> CreateCompanyAsync(CreateCompany givenCompany)
        {
            return await _companyRepository.CreateCompanyAsync(givenCompany);
        }
        public async Task<List<CompanyWithoutOwners>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllCompaniesAsync();
        }
        public async Task<Company> GetCompanyDetailsAsync(int id)
        {
            return await _companyRepository.GetCompanyDetailsAsync(id);
        }
        public async Task UpdateCompanyAsync(int id, CreateCompany updateInformation)
        {
            await _companyRepository.UpdateCompanyAsync(id, updateInformation);
        }
        public async Task AddOwnerToCompanyAsync(int companyId, string ownerName, string ownerSocSecNumber)
        {
            await _companyRepository.AddOwnerToCompanyAsync(companyId, ownerName, ownerSocSecNumber);
        }
    }
}