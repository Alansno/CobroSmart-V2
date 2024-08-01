using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Payment : SoftDeleteBase
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatePayment { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPayment { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; }
        public DateTime? HisPayment { get; set; }
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; } = null;
        public int? InterestId { get; set; }
        public Interest? Interest { get; set; } = null;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null;
    }
}
