using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketECommerceWebApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Employee { get; set; }

        [Required]
        [DisplayName("Customer Name")]
        [Column(TypeName = "nvarchar(250)")]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("Phone No.")]
        [Column(TypeName = "nvarchar(1250)")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(550)")]
        public string Items { get; set; }

        
        [Required]
        [DisplayName("Order Cost")]
        [Column(TypeName = "nvarchar(550)")]
        public string OrderCost { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1250)")]
        public string Date { get; set; }
    }
}
