﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Customer
    {
        public int customerId { get; set; }
        public List<Products> products { get; set; }
    }
}