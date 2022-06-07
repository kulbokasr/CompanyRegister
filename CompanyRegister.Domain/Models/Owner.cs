using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister.Domain.Models
{
    public class Owner : NamedEntity
    {
        public string SocialSecNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
