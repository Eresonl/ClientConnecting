using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Services
{
    public class ClientService
    {
        private readonly ClientConnectingContext _context;

        public ClientService(ClientConnectingContext context)
        {
            _context = context;
        }

        public List<Client> FindAll()
        {
            return _context.Client.ToList();
        }

        public void Insert(Client obj)
        {
            Random id = new Random();

            obj.Id = id.Next(200);
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
