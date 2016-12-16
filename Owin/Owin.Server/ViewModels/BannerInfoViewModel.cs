using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class BannerInfoViewModel
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }

        [DataMember(Name = "position")]
        public PositionViewModel Position {get; set;}
    }
}