using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketECommerceWebApp.Models
{
    public class ProductCatagory
    {
        [Key]
        public int CatagoryId { get; set; }

        [Required]
        [DisplayName("Catagory Name")]
        [Column(TypeName="nvarchar(250)")]
        public string CatagoryName { get; set; }
        
    }
}
