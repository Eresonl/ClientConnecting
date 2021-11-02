using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Services
{
    public class CategoryService
    {
        private readonly ClientConnectingContext _context;

        public CategoryService(ClientConnectingContext context)
        {
            _context = context;
        }

        public List<Category> FindAll()
        {
            return _context.Category.OrderBy( cat => cat.Name).ToList();
        }
    }
}
