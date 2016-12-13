using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json.Linq;
using Owin.Server.ViewModels;

namespace Owin.Server.Controllers
{
    public class ProjectOwnersController : ApiController
    {
        // GET: api/ProjectOwners
        public IEnumerable<UserViewModel> Get()
        {
            return DB.Users.Select(user => new UserViewModel 
            {
                Id = user.Id.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl
            });
        }
    }
}
