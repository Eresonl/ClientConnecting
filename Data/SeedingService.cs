using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientConnecting.Models;

namespace ClientConnecting.Data
{
    public class SeedingService
    {
        private ClientConnectingContext _context;

        public SeedingService(ClientConnectingContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Company.Any() || _context.Client.Any() || _context.Product.Any() || _context.Category.Any())
            {
                return;
            }
            Client client1 = new Client { Id = 1, Name = "Carlos", Address = "Rua Ant Carlos, 120", BirthDate = new DateTime(1996, 4, 21), Cpf = "485.856" };
            Client client2 = new Client { Id = 2, Name = "Emerson", Address = "Rua Pr Emerson, 120", BirthDate = new DateTime(1996, 4, 21), Cpf = "485.856.9" };
            Client client3 = new Client { Id = 3, Name = "Gabriel", Address = "Rua Sao Gabriel, 120", BirthDate = new DateTime(1996, 4, 21), Cpf = "485.859" };
            Client client4 = new Client { Id = 4, Name = "Nilce", Address = "Rua Maria Nilce, 120", BirthDate = new DateTime(1996, 4, 21), Cpf = "485.856.9" };
            Client client5 = new Client { Id = 5, Name = "Vinicius", Address = "Rua Vinicius de Moraes, 120", BirthDate = new DateTime(1996, 4, 21), Cpf = "48520-39" };
            Client client6 = new Client { Id = 6, Name = "Paula", Address = "Rua Paula Fernandes, 120", BirthDate = new DateTime(1996, 4, 21), Cpf = "485.-39" };

            Company c1 = new Company { Id = 7, Address = "Rua São Paulo, numero 970", CategoryId = 1, Cnpj = "09.758.251", Email = "petshopnewpet@gmail.com", Name = "New Pet", ImagemLogo = "logo1.jpg" };
            Company c2 = new Company { Id = 8, Address = "Rua Bahia, numero 340", CategoryId = 1, Cnpj = "50.096.459", Email = "bawbaw@gmail.com", Name = "Baw Baw", ImagemLogo = "logo2.jpg" };
            Company c3 = new Company { Id = 9, Address = "Rua Rio Grande do Sul, numero 562", CategoryId = 1, Cnpj = "25.444.30", Email = "petslife@gmail.com", Name = "Petslife", ImagemLogo = "logo3.jpg" };
            Company c4 = new Company { Id = 10, Address = "Rua Mato Grosso, numero 854", CategoryId = 1, Cnpj = "39.022.863", Email = "dogsfriend@gmail.com", Name = "Dogs Friend", ImagemLogo = "logo4.jpg" };
            Company c5 = new Company { Id = 11, Address = "Rua Espirito Santo, numero 1001", CategoryId = 1, Cnpj = "21.706.56", Email = "catlove@gmail.com", Name = "Cat Love", ImagemLogo = "logo1.jpg" };
            Company c6 = new Company { Id = 12, Address = "Rua Curitiba, numero 488", CategoryId = 1, Cnpj = "15.321.365", Email = "animalscare@gmail.com", Name = "Animals Care", ImagemLogo = "logo2.jpg" };

            Product p1 = new Product { Id = 13, Code = 1223, ProductDescription = "Ração para Cachoros", ProductType = "Ração", Company = c1, CategoryId = 126 };
            Product p2 = new Product { Id = 23, Code = 1223, ProductDescription = "Ração para Gatos", ProductType = "Ração", Company = c2, CategoryId = 78 };
            Product p3 = new Product { Id = 34, Code = 1223, ProductDescription = "Coleira para Cachorros", ProductType = "Coleira", Company = c3, CategoryId = 96 };
            Product p4 = new Product { Id = 45, Code = 1223, ProductDescription = "Bolinha para Cachoros", ProductType = "Brinquedos", Company = c4, CategoryId = 78 };
            Product p5 = new Product { Id = 56, Code = 1223, ProductDescription = "Arranhador para Gatos", ProductType = "Brinquedos", Company = c5, CategoryId = 126 };
            Product p6 = new Product { Id = 67, Code = 1223, ProductDescription = "Shampoo para animais", ProductType = "Cosmeticos", Company = c6, CategoryId = 126 };

            Category cat1 = new Category { Id = 126, Name = "Petshop" };
            Category cat2 = new Category { Id = 78, Name = "Varejo" };
            Category cat3 = new Category { Id = 96, Name = "Alimentação" };

            _context.Company.AddRange(c1, c2, c3, c4, c5, c6);
            _context.Product.AddRange(p1, p2, p3, p4, p5, p6);
            _context.Client.AddRange(client1, client2, client3, client4, client5, client6);
            _context.Category.AddRange(cat1, cat2, cat3);

            _context.SaveChanges();
        }
    }
}
