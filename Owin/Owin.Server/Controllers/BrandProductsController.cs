using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Owin.Server.Controllers
{
    public class BrandProductsController : ApiController
    {
        // GET: api/BrandProducts
        public JArray Get()
        {
            return JArray.Parse(File.ReadAllText(@"./test_data/brandProducts.json"));
        }
    }
}
