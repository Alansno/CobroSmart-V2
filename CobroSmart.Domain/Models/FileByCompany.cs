using CobroSmart.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class FileByCompany : SoftDeleteBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string NameFile { get; set; }
        public FileEnum Type { get; set; }
        public string Url { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null;
    }
}
