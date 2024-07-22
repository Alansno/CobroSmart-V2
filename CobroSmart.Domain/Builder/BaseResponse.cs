﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Builder
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
