using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClientConnecting.Services
{
    public class ClientService
    {
        private readonly ClientConnectingContext _context;

        public ClientService(ClientConnectingContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> FindAllAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task InsertAsync(Client obj)
        {
            Random id = new Random();

            obj.Id = id.Next(200);
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
    }
}
