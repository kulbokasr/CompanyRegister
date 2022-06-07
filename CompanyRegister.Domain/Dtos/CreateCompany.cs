using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Models
{
    public class CreateCompany
    {
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
    }
}
