using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Response
{
    public class AuthResponse
    {
        public string JWT { get; set; }
        public int Id { get; set; }
        public string Username { get; set; }

    }
}
