using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Owin.Server.Controllers
{
    public class ProjectTypesController : ApiController
    {
        // GET: api/ProjectTypes
        public JArray Get()
        {
            return JArray.Parse(File.ReadAllText(@"./test_data/projectTypes.json"));
        }
    }
}
