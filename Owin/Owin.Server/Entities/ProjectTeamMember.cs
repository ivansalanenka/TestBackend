using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Owin.Server.Entities
{
    public class ProjectTeamMember
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}