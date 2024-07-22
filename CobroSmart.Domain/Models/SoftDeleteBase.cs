using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public abstract class SoftDeleteBase
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        [ConcurrencyCheck]
        public DateTime UpdatedAt { get; set; }
    }
}
