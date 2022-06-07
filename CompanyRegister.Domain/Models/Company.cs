using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Models
{
    public class Company : NamedEntity
    {
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
