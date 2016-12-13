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
    public class ScopesController : ApiController
    {
        // GET: api/Scopes
        public IEnumerable<ScopeViewModel> Get()
        {
            return DB.Scopes.Select(scope => new ScopeViewModel 
            {
                Id = scope.Id.ToString(),
                Label = scope.Name,
                IconId = scope.IconId,
                CategoryId = scope.CategoryId.ToString()
            });
        }
    }
}
