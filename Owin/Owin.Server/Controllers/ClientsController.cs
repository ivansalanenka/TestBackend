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
    public class ClientsController : ApiController
    {
        public IEnumerable<ClientViewModel> Get()
        {
            return DB.Clients.Select(client => new ClientViewModel
            {
                Id = client.Id.ToString(),
                Name = client.Name
            });
        }
    }
}
