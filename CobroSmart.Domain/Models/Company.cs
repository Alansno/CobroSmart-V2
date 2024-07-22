using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Company : SoftDeleteBase
    {
        public int Id { get; set; }
        public DateTime DateEntry { get; set; }
        public string NameCompany { get; set; }
        public string AddressCompany { get; set; }
        public string EmailCompany { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumberCompany { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string TypeCompany { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Employees> Employees { get; } = new List<Employees>();
        public ICollection<Client> Client { get; } = new List<Client>();
        public ICollection<Account> Account { get; } = new List<Account>();
        public ICollection<Discount> Discount { get; } = new List<Discount>();
        public ICollection<Interest> Interest { get; } = new List<Interest>();
        public ICollection<FileByCompany> FileByCompany { get; } = new List<FileByCompany>();
    }
}
