﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}