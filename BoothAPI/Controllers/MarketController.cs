using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private IMarketBll _marketBll;
        public MarketController(IMarketBll marketBll)
        {
            this._marketBll = marketBll;
        }

        public int AddMarket(MarketInfo model)
        {
            return _marketBll.AddMarket(model);
        }

        public int DelMarket(object id)
        {
            return _marketBll.DelMarket(id);
        }

        public int UpdateMarket(MarketInfo model)
        {
            return _marketBll.UptMarket(model);
        }
    }
}