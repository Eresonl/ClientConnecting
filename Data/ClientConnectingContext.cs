using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientConnecting.Models;

namespace ClientConnecting.Models
{
    public class ClientConnectingContext : DbContext
    {
        public ClientConnectingContext (DbContextOptions<ClientConnectingContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
