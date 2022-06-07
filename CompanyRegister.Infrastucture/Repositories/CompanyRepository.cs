using CompanyRegister.Domain.Dtos;
using CompanyRegister.Domain.Interfaces;
using CompanyRegister.Domain.Models;
using CompanyRegister.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Infrastucture.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _dataContext;

        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            Company company = await _dataContext.Companies.Where(i => i.Id == id).Include(c => c.Owners).FirstOrDefaultAsync();
            if (company == null)
            {
                throw new ArgumentException("Company with such Id does not exist");
            }
            return company;
        }

        public async Task<Company> CreateCompanyAsync(CreateCompany givenCompany)
        {
            bool doesNameExist = await _dataContext.Companies.AnyAsync(x => x.Name == givenCompany.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("Company with such name already exists");
            }
            Company company = new Company()
            {
                Name = givenCompany.Name,
                Country = givenCompany.Country,
                PhoneNumber = givenCompany.PhoneNumber
            };
            _dataContext.Companies.Add(company);
            await _dataContext.SaveChangesAsync();
            return company;
        }
        public async Task<List<CompanyWithoutOwners>> GetAllCompaniesAsync()
        {
            List<Company> companies = await _dataContext.Companies.ToListAsync();
            List<CompanyWithoutOwners> companiesWithoutOwners = new List<CompanyWithoutOwners>();
            foreach (Company company in companies)
            {
                CompanyWithoutOwners companyWithoutOwners = new CompanyWithoutOwners()
                {
                    Country = company.Country,
                    PhoneNumber = company.PhoneNumber,
                    Name = company.Name,
                    Id = company.Id
                };
                companiesWithoutOwners.Add(companyWithoutOwners);
            }
            return companiesWithoutOwners;
        }
        public async Task<Company> GetCompanyDetailsAsync(int id)
        {
            Company company = await GetCompanyByIdAsync(id);
            return company;
        }
        public async Task UpdateCompanyAsync(int id, CreateCompany updateInformation)
        {
            Company company = await GetCompanyByIdAsync(id);
            bool doesNameExist = await _dataContext.Companies.AnyAsync(x => x.Name == updateInformation.Name);
            if (doesNameExist)
            {
                throw new ArgumentException("Company with such name already exists");
            }
            company.Name = updateInformation.Name;
            company.Country = updateInformation.Country;
            company.PhoneNumber = updateInformation.PhoneNumber;
            await _dataContext.SaveChangesAsync();
        }
        public async Task AddOwnerToCompanyAsync(int companyId, string ownerName, string ownerSocSecNumber)
        {
            Company company = await GetCompanyByIdAsync(companyId);
            Owner owner = new Owner()
            {
                Name = ownerName,
                SocialSecNumber = ownerSocSecNumber
            };
            company.Owners.Add(owner);
            await _dataContext.SaveChangesAsync();
        }
    }
}
