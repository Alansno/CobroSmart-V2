using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.QueryBase
{
    public class PasswordResult
    {
        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
