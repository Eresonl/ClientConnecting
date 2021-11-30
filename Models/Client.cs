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

        [Required(ErrorMessage = "Por favor, informe o nome!")]
        public string Name { get; set; }
        public string Cpf { get; set; }

        [Required(ErrorMessage = "E Necessario inserir um email valido!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor, insira um Email valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o e-mail!")]
        [DataType(DataType.EmailAddress)]
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "É necessário confirmar sua senha.")]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais nos dois campos.")]
        public string ConfirmPassword { get; set; }

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
