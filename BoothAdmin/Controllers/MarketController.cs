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
     
        public IActionResult Index()
        {
           
            return View();
           
        }
        //通过调用api做显示
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
            
        }



        public IActionResult AddMarket()
        {
            return View();
        }

       public IActionResult UpdateMarket(object id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult DelMarket(Object id)
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