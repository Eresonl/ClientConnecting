using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Models
{
    public class CompanyDetailsViewModel
    {
        public Company Company { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
