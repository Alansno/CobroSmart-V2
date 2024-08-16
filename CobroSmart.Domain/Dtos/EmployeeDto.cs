using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Dtos
{
    public class EmployeeDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string NameEmployee { get; set; }
        [Required]
        [EmailAddress]
        public string EmailEmployee { get; set; }
        [Required]
        [Phone]
        public string PhoneNumberEmployee { get; set; }
    }
}
