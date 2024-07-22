using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class TokenRevocation
    {
        [Key]
        public int UserId { get; set; }
        public DateTime LastRevocationTime { get; set; }
        public User User { get; set; } = null;
    }
}
