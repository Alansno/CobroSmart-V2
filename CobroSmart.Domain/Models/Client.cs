using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Client : SoftDeleteBase
    {
        public int Id { get; set; }
        public string NameClient { get; set; }
        public DateTime DateEntry { get; set; }
        public string AddressClient { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumberClient { get; set; }
        public string EmailClient { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null;
        public int? EmployeeId { get; set; }
        public Employees? Employees { get; set; } = null;
        public ICollection<Service> Service { get; } = new List<Service>();
        public BlackList? BlackList { get; set; }
    }
}
