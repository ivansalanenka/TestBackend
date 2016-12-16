using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int MarketId { get; set; }
        public int ProjectTypeId { get; set; }
        public int OwnerId { get; set; }
        public ProjectBannerInfo BannerInfo { get; set; }
    }
}