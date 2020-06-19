using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BoothAdmin.Controllers
{
    public class MarketController : Controller
    {
        //private IMarketBll _marketBll;
        //public MarketController(IMarketBll marketBll)
        //{
        //    this._marketBll = marketBll;
        //}
        public IActionResult Index()
        {
            //string url = "http://localhost:52229/api/Market/ShowMarket";
            //HttpClient client = new HttpClient();

            //HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            //string s = httpResponse.Content.ReadAsStringAsync().Result;
            //List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            //List<MarketInfo> list = _marketBll.ShowMarket(page,limit);
            //int PageCount = (list == null || list.Count == 0) ? 0 : list.Count;
            //int c = (int)Math.Ceiling((decimal)PageCount / limit);
            //ViewBag.parper = (page <= 1) ? 1 : page - 1;
            //ViewBag.pagenext = page >= c ? c : page + 1;
            //ViewBag.pahelast = c;
            //return Json(new LayUi { code = "0", msg = "", count = PageCount.ToString(), data = list });
            return View();
           
        }
        public ActionResult SelectMarket(int page=1,int limit=10)
        {

            string url = "http://localhost:52229/api/Market/ShowMarket";
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
          
            int PageCount = (list == null || list.Count == 0) ? 0 : list.Count;
            int c = (int)Math.Ceiling((decimal)PageCount / limit);
            ViewBag.parper = (page <= 1) ? 1 : page - 1;
            ViewBag.pagenext = page >= c ? c : page + 1;
            ViewBag.pahelast = c;
            return Json(new LayUi { code = "0", msg = "", count = PageCount.ToString(), data = list });
            //List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            //return View(list);
            //return View();
        }



        public IActionResult AddMarket()
        {
            return View();
        }

       public IActionResult UptMarkert()
        {
            return View();
        }
        public class LayUi
        {
            public string code { get; set; }
            public string msg { get; set; }
            public string count { get; set; }
            public object data { get; set; }
        }

    }
}