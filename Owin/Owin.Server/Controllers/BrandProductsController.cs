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
    public class BrandProductsController : ApiController
    {
        // GET: api/BrandProducts
        public IEnumerable<BrandViewModel> Get(int clientId)
        {
            return DB.Brands.Where(brand => brand.ClientId == clientId).Select(brand => new BrandViewModel
            {
                Id = brand.Id.ToString(),
                Name = brand.Name,
                ClientId = brand.ClientId.ToString(),
                Products = DB.Products.Where(product => product.BrandId == brand.Id).Select(product => new ProductViewModel 
                { 
                    Id = product.Id.ToString(),
                    BrandId = product.BrandId.ToString(),
                    Name = product.Name
                })
            });
        }
    }
}
