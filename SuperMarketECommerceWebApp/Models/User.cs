using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketECommerceWebApp.Models
{
    public class User
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [DisplayName("First Name")]
        [Column(TypeName = "nvarchar(250)")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Second Name")]
        [Column(TypeName = "nvarchar(250)")]
        public string SecondName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Position { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1250)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1250)")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Phone No.")]
        [Column(TypeName = "nvarchar(1250)")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Contact Address")]
        [Column(TypeName = "nvarchar(1250)")]
        public string ContactAddress { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        [Column(TypeName = "nvarchar(1250)")]
        public string DateOfBirth { get; set; }
    }
}
