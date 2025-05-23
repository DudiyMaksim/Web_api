﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_api.BLL.Configuration
{
    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public int ExpMinutes { get; set; }
    }
}
