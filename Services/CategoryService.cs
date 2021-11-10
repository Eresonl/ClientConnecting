using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClientConnecting.Services
{
    public class CategoryService
    {
        private readonly ClientConnectingContext _context;

        public CategoryService(ClientConnectingContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Category.OrderBy( cat => cat.Name).ToListAsync();
        }
    }
}
