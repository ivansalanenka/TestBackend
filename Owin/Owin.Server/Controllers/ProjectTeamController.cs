using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Owin.Server.Controllers
{
    public class ProjectTeamController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return DB.Users.Where(user => user.Id % 3 == 0).Select(user => user.Id.ToString());
        }
    }
}
