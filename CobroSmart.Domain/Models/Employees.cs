using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Employees : SoftDeleteBase
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string EmailEmployee { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumberEmployee { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null;
        public ICollection<Client> Client { get; } = new List<Client>();
        public ICollection<Service> Service { get; } = new List<Service>();
    }
}
