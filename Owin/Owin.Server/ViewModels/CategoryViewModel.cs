using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class CategoryViewModel
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "color")]
        public string Color { get; set; }
    }
}