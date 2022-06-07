using CompanyRegister.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Dtos
{
    public class CompanyWithoutOwners : NamedEntity
    {
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
    }
}
