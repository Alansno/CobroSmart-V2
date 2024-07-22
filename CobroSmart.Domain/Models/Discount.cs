﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class Discount : SoftDeleteBase
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal QuantityDiscount { get; set; }
        public int TermsDiscount { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null;
        public ICollection<Payment> Payment { get; } = new List<Payment>();
    }
}
