using ClientConnecting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Services
{
    public class ProductService
    {
        private readonly ClientConnectingContext _context;

        public ProductService(ClientConnectingContext context)
        {
            _context = context;
        }

        public List<Product> FindAll()
        {
            return _context.Product.ToList();
        }

        public void Insert(Product obj)
        {
            Random id = new Random();

            obj.Id = id.Next(200);
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Product.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Product.Find(id);
            _context.Product.Remove(obj);
            _context.SaveChanges();
        }
    }
}
