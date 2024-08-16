using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Dtos
{
    public class ClientDto
    {
        [Required]
        public string NameClient { get; set; }
        [Required]
        public string AddressClient { get; set; }
        [Required]
        [Phone]
        public string PhoneNumberClient { get; set; }
        [Required]
        [EmailAddress]
        public string EmailClient { get; set; }
        [Required]
        public string TimeZone { get; set; }
    }
}
