using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientConnecting.Models
{
    [Table("Client")]
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Company> Company { get; set; } = new List<Company>();

        public Client()
        {

        }

        public Client(int id, string name, string cpf, string address, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Address = address;
            BirthDate = birthDate;
        }

        public void SubscribeCompany(Company company)
        {
            Company.Add(company);
        }

        public void UnscribeCompany(Company company)
        {
            Company.Remove(company);
        }
    }
}
