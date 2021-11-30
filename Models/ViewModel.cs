using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Models
{
    public class ViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Company> Companies { get; set; }
    }
}
