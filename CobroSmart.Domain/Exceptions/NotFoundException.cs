﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Message) : base(Message)
        {
            
        }
    }
}
