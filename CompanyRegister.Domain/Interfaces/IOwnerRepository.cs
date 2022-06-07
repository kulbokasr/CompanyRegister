using CompanyRegister.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner> GetOwnerByIdAsync(int id);
    }
}
