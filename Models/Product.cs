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
        [Key]
        public int ProductID { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }

    }
}
