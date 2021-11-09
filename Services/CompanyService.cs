using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClientConnecting.Services
{
    public class CompanyService
    {
        private readonly ClientConnectingContext _context;

        public CompanyService(ClientConnectingContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> FindAllAsync()
        {
            return await _context.Company.OrderBy(obj => obj.Name).ToListAsync();
        }

        public async Task<Company> FindByIdAsync(int id)
        {

            return await _context.Company.Include(obj => obj.Product).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task InsertAsync(Company obj)
        {
            Random id = new Random();

            obj.Id = id.Next(200);
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async  Task<List<Company>> FindByNameAsync(string name)
        {
            var result = from obj in _context.Company select obj;

            if(!String.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.Name!.Contains(name));

            }
            

            return await result.ToListAsync();
        }
    }
}
