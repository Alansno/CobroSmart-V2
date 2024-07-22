using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Account : SoftDeleteBase
    {
        public int Id { get; set; }
        public string NameAccount { get; set; }
        public string Clabe {  get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null;
        public ICollection<Service> Service { get; } = new List<Service>();
    }
}
