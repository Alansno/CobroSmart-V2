using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class User : SoftDeleteBase
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null;
        public Company? Company { get; set; }
        public Employees? Employees { get; set; }
        public ICollection<TokenRevocation> TokenRevocation { get; } = new List<TokenRevocation>();
    }
}
