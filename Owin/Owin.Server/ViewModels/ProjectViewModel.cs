using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Owin.Server.ViewModels
{
    [DataContract]
    public class ProjectViewModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "ownerId")]
        public int OwnerId { get; set; }

        [DataMember(Name = "teamMembersIds")]
        public IEnumerable<int> TeamMembersIds { get; set; }

        [DataMember(Name = "client")]
        public string Client { get; set; }

        [DataMember(Name = "market")]
        public string Market { get; set; }

        [DataMember(Name = "bannerInfo")]
        public BannerInfoViewModel BannerInfo { get; set; }

        [DataMember(Name = "projectScopes")]
        public IDictionary<int, ProjectScopeViewModel> ProjectScopes { get; set; }
    }
}