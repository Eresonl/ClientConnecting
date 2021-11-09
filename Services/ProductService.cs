using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClientConnecting.Services
{
    public class ProductService
    {
        private readonly ClientConnectingContext _context;

        public ProductService(ClientConnectingContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task InsertAsync(Product obj)
        {
            Random id = new Random();

            obj.Id = id.Next(200);
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = _context.Product.Find(id);
            _context.Product.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}
