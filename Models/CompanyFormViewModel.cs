using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Models
{
    public class CompanyFormViewModel
    {
        public Company Company { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
