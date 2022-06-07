using CompanyRegister.Domain.Interfaces;
using CompanyRegister.Domain.Models;
using CompanyRegister.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Infrastucture.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Owner> GetOwnerByIdAsync(int id)
        {
            Owner owner = await _dataContext.Owners.FindAsync(id);
            if (owner == null)
            {
                throw new ArgumentException("Owner with such Id does not exist");
            }
            return owner;
        }
    }
}
