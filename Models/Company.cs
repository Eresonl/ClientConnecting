using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Models
{
    [Table("Company")]
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, insira um nome valido!")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, insira um CNPJ valido!")]
        [MaxLength(14, ErrorMessage = "Máximo de 14 digitos!")]
        public string Cnpj { get; set; }

        public string Address { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "E Necessario inserir um email valido!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor, insira um Email valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "É necessário confirmar sua senha.")]
        [Compare("Password", ErrorMessage = "As senhas devem ser iguais nos dois campos.")]
        public string ConfirmPassword { get; set; }

        public string ImagemLogo { get; set; }

        public ICollection<Client> Clients { get; set; } = new List<Client>();

        public ICollection<Product> Product { get; set; } = new List<Product>();

        public Perfil Perfil { get; set; }

        public Company()
        {

        }

        public Company(int id, string name, string cnpj, string address, int categoryId, string email, string imagemLogo)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Address = address;
            CategoryId = categoryId;
            Email = email;
            ImagemLogo = imagemLogo;
        }

        public void AddProducts(Product product)
        {
            Product.Add(product);
        }
    }
    public enum Perfil
    {
        Company,
        Client
    }
}
