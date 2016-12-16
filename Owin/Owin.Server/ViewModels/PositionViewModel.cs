using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class PositionViewModel
    {
        [DataMember(Name = "top")]
        public int Top { get; set; }

        [DataMember(Name = "left")]
        public int Left { get; set; }
    }
}