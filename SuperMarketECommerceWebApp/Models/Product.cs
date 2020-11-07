using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketECommerceWebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        [Column(TypeName="nvarchar(250)")]
        public string ProductName { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Catagory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1250)")]
        public string Info { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
