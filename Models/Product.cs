using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientConnecting.Models
{
   [Table("Product")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public Company Company { get; set; }

        public Product()
        {

        }

        public Product(int id, int code, string productType, string productDescription, Company company)
        {
            Id = id;
            Code = code;
            ProductType = productType;
            ProductDescription = productDescription;
            Company = company;
        }
    }
}
