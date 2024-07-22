using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Service : SoftDeleteBase
    {
        public int Id { get; set; }
        public string NameService { get; set; }
        public string TypeService { get; set; }
        public string DescriptionService { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalService { get; set; }
        public int Terms { get; set; }
        public string Status { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalInterest { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Difference { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateLiquidation { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null;
        public int AccountId { get; set; }
        public Account Account { get; set; } = null;
        public int EmployeeId { get; set; }
        public Employees Employees { get; set; } = null;
        public ICollection<Payment> Payment { get; } = new List<Payment>();

    }
}
