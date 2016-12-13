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
    public class RegionMarketsController : ApiController
    {
        // GET: api/RegionMarkets
        public IEnumerable<RegionViewModel> Get(int clientId)
        {
            var clientMarketsIds = DB.ClientMarkets
                                    .Where(cm => cm.ClientId == clientId)
                                    .Select(cm => cm.MarketId);

            var clientRegionsIds = DB.Markets
                                    .Where(market => clientMarketsIds.Contains(market.Id))
                                    .Select(market => market.RegionId)
                                    .Distinct();

            return DB.Regions.Where(region => clientRegionsIds.Contains(region.Id)).Select(region => new RegionViewModel
            {
                Id = region.Id.ToString(),
                Name = region.Name,
                Markets = DB.Markets.Where(market =>
                {
                    return market.RegionId == region.Id && clientMarketsIds.Contains(market.Id);
                }).Select(market => new MarketViewModel {
                    Id = market.Id.ToString(),
                    Name = market.Name,
                    RegionId = market.RegionId.ToString()
                })
            });
        }
    }
}
