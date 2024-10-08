﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Models
{
    public class BlackList : SoftDeleteBase
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
