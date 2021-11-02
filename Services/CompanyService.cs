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

        public List<Company> FindAll()
        {
            return _context.Company.OrderBy(obj => obj.Name).ToList();
        }

        public Company FindById(int id)
        {

            return _context.Company.Include(obj => obj.Product).FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(Company obj)
        {
            Random id = new Random();

            obj.Id = id.Next(200);
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
