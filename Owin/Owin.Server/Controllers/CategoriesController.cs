using Newtonsoft.Json.Linq;
using Owin.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Owin.Server.Controllers
{
    public class CategoriesController : ApiController
    {
        public IEnumerable<CategoryViewModel> Get()
        {
            return DB.Categories.Select(category => new CategoryViewModel 
            {
                Id = category.Id.ToString(),
                Label = category.Name,
                Color = category.Color
            });
        }
    }
}
