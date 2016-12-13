using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class Scope
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconId { get; set; }
        public int CategoryId { get; set; }
    }
}