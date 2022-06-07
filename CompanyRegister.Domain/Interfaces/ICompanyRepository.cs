using CompanyRegister.Domain.Dtos;
using CompanyRegister.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> CreateCompanyAsync(CreateCompany givenCompany);
        Task<List<CompanyWithoutOwners>> GetAllCompaniesAsync();
        Task<Company> GetCompanyDetailsAsync(int id);
        Task UpdateCompanyAsync(int id, CreateCompany updateInformation);
        Task AddOwnerToCompanyAsync(int companyId, string ownerName, string ownerSocSecNumber);
    }
}
