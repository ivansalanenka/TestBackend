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
    public class ProjectTypesController : ApiController
    {
        // GET: api/ProjectTypes
        public IEnumerable<ProjectTypeViewModel> Get()
        {
            return DB.ProjectTypes.Select(projectType => new ProjectTypeViewModel 
            { 
                Id = projectType.Id.ToString(),
                Name = projectType.Name
            });
        }
    }
}
