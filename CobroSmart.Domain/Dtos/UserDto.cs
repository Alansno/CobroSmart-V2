using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Dtos
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string NameCompany { get; set; }
        [Required]
        public string AddressCompany { get; set; }
        [Required]
        [EmailAddress]
        public string EmailCompany { get; set; }
        [Required]
        [Phone]
        public string PhoneNumberCompany { get; set; }
        [Required]
        public string TypeCompany { get; set; }
    }
}
