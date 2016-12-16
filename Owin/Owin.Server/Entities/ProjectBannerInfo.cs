using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class ProjectBannerInfo
    {
        public string ImageUrl { get; set; }
        public Position ImagePosition { get; set; }
        public string Color { get; set; }
    }
}