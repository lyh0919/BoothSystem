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
        private ICity _cityBll;
        public MarketController(IMarketBll marketBll,ICity cityBll)
        {
            this._marketBll = marketBll;
            this._cityBll = cityBll;
        }


        [HttpPost]
        public int AddMarket(MarketInfo model)
        {
            return _marketBll.AddMarket(model);
        }

        public int DelMarket(Guid id)
        {
            return _marketBll.DelMarket(id);
        }

        public int UpdateMarket(MarketInfo model)
        {
            return _marketBll.UptMarket(model);
        }


      
        public List<MarketInfo> ShowMarket()
        {
           List<MarketInfo> list= _marketBll.ShowMarket();
          
            return list;
        }

        public List<MarketInfo> ShowDetial(Guid id)
        {
            List<MarketInfo> list = _marketBll.ShowDetial(id);
            return list;
        }





       


        public List<City> GetCity(int id)
        {
            return _marketBll.GetCity(c => c.PId==id);
        }

    } 
}