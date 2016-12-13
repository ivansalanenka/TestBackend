using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}