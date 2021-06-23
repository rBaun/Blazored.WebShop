﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blazored.WebShop.Core.Business.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
