﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpPOC.Models.Request
{
    public class CreateUserReq 
    {
        public string name { get; set; }
        public string job { get; set; }
    }
}