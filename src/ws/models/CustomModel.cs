using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json.Linq;

namespace template.api.wsclient 
{
    public class CustomModel: Model 
    {
        public string name { get; set; }
        public string aaa { get; set; }
    }
}