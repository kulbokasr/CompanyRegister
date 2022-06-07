using CompanyRegister.Domain.Interfaces;
using CompanyRegister.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Services
{
    public class OwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task<string> ValidateSocSecNumbAsync(int id)
        {
            Owner owner = await _ownerRepository.GetOwnerByIdAsync(id);
            if (owner.SocialSecNumber == "validation")
            {
                return "string";
            }

            Random rnd = new Random();
            int number = rnd.Next(1, 3);
            switch (number)
            {
                case 1:
                    return "valid";
                case 2:
                    return "invalid";
                default:
                    return "not possible";
            }
        }
    }
}
