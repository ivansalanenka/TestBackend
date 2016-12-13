using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class BrandViewModel
    {
        [DataMember(Name="id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "clientId")]
        public string ClientId { get; set; }

        [DataMember(Name = "products")]
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}