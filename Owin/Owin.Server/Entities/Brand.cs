using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
    }
}