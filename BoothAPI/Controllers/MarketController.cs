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
    [Route("api/[controller]/[action]")]
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


      
        public List<MarketInfo> ShowMarket(int page = 1,int limit = 10)
        {
           List<MarketInfo> list= _marketBll.ShowMarket();
            list = list.Skip((page - 1) * limit).Take(limit).ToList();

            return list;
        }
    }
}