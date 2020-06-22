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
        public ActionResult SelectMarket(int page=2,int limit=10)
        {

            string url = "http://localhost:52229/api/Market/ShowMarket";
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            list = list.Skip((page - 1) * limit).Take(limit).ToList();

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

        [HttpPost]
        public int Add(MarketInfo m)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/Market/AddMarket";
            m.Id = Guid.NewGuid();
            m.CreateTime = DateTime.Now;
            m.UpdateTime = DateTime.Now;
            m.MarkSortId = 2;
            string stu = JsonConvert.SerializeObject(m);
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(stu);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            message = client.PostAsync(url,content).Result;
            string s= message.Content.ReadAsStringAsync().Result;
            return Convert.ToInt32(s);

        }

   


       public IActionResult UpdateMarket(Guid id)
        {
            string url = "http://localhost:52229/api/Market/ShowDetial?id=" + id;
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            return View(list.First());
        }
        
      [HttpPost]
      public int UpdateMarket(MarketInfo m)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/Market/UpdateMarket";
            MarketInfo model = new MarketInfo
            {
                CreateTime = DateTime.Now,
                IsEnable = m.IsEnable,
                MarkAccName = m.MarkAccName,
                MarkAddress = m.MarkAddress,
                MarkName = m.MarkName,
                MarkPhone = m.MarkPhone,
                MarkSortId = m.MarkSortId,
                UpdateTime = m.UpdateTime
            };
            string stu = JsonConvert.SerializeObject(model);
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(stu);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            message = client.PutAsync(url, content).Result;
            string s = message.Content.ReadAsStringAsync().Result;
            return Convert.ToInt32(s);
        }
        [HttpPost]
        public int DelMarket(Guid id)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/Market/DelMarket?id=" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });
            //HttpContent content = new StringContent(id);
            //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            message = client.DeleteAsync(url).Result;
            string s = message.Content.ReadAsStringAsync().Result;
           
         
            return Convert.ToInt32(s);
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