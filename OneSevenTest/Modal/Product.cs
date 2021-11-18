﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSevenTest.Modal
{
    public class Product
    {
        public string? id { get; set; }
        public string? title { get; set; }
        public string? price { get; set; } 
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public rating? rating { get; set; }  
    }
}
