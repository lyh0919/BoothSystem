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
     
        #region   市场管理
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
            list = list.Skip((page - 1) * limit).Take(limit).ToList();

            int PageCount = (list == null || list.Count == 0) ? 0 : list.Count;
            int c = (int)Math.Ceiling((decimal)PageCount / limit);
            ViewBag.parper = (page <= 1) ? 1 : page - 1;
            ViewBag.pagenext = page >= c ? c : page + 1;
            ViewBag.pahelast = c;
            return Json(new LayUi { code = "0", msg = "", count = PageCount.ToString(), data = list });
            
        }


        public ActionResult SearchMarket(string name="",string isables="1")
        {
            string url = "http://localhost:52229/api/market/SearchMarket?name=" + name + "&isable=" + isables;
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            if (list.Count==0)
            {
                return Json(new LayUi { code = "1", msg = " 没有找到相关记录，请更换查询条件或查询关键字试试", count = 0.ToString(), data = "" });
            }
            else
            {
               
                return Json(new LayUi { code = "0", msg = "", count = list.Count.ToString(), data = list });
            }

        }

        public IActionResult AddMarket()
        {
            return View();
        }

        //添加数据
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

   

        //反填数据
       public IActionResult UpdateMarket(Guid id)
        {
            string url = "http://localhost:52229/api/Market/ShowDetial?id=" + id;
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            return View(list.First());
        }
        

        //修改市场
      //[HttpPost]
      //public int UpdateMarket(MarketInfo m)
      //  {
      //      HttpResponseMessage message = null;
      //      string url = "http://localhost:52229/api/Market/UpdateMarket";
      //      MarketInfo model = new MarketInfo
      //      {
      //          Id=m.Id,
      //          CreateTime = DateTime.Now,
      //          IsEnable = m.IsEnable,
      //          MarkAccName = m.MarkAccName,
      //          MarkAddress = m.MarkAddress,
      //          MarkName = m.MarkName,
      //          MarkPhone = m.MarkPhone,
      //          MarkSortId = m.MarkSortId,
      //          UpdateTime = DateTime.Now
      //      };
      //      string stu = JsonConvert.SerializeObject(model);
      //      HttpClient client = new HttpClient();
      //      HttpContent content = new StringContent(stu);
      //      content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
      //      message = client.PutAsync(url, content).Result;
      //      string s = message.Content.ReadAsStringAsync().Result;
      //      return Convert.ToInt32(s);
      //  }



        //删除市场 通过传入id进行删除
        [HttpPost]
        public int DelMarket(Guid id)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/Market/DelMarket?id=" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });
           
            message = client.DeleteAsync(url).Result;
            string s = message.Content.ReadAsStringAsync().Result;
           
         
            return Convert.ToInt32(s);
        }

        #endregion


        #region   摊位管理
        //摊位管理
        public IActionResult ShowBooth()
        {
            return View();
        }


        public IActionResult AddBoo()
        {
            return View();
        }


        public IActionResult EditBoo(Guid id)
        {
            ViewBag.MarketShow = SearchMarket("","");
            string url = "http://localhost:52229/api/Market/ShowBooDetial?id=" + id;
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            return View(list.First());
            
        }
        #endregion



        #region  出租明细历史
        public IActionResult DetialBoothAndUser()
        {
            return View();
        }
        #endregion



        #region
        public IActionResult BooAucalInfoShow()
        {
            return View();
        }

        public IActionResult AddBooAucalInfo()
        {
            return View();
        }
        public IActionResult UpdateBooAucalInfo(Guid id)
        {
            ViewBag.ShowBooInfo = ShowBooInfo();
            string url = "http://localhost:52229/api/Market/ShowDetialOne?id=" + id;
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MarketInfo> list = JsonConvert.DeserializeObject<List<MarketInfo>>(s);
            return View(list.First());
        }

        public List<BooInfo> ShowBooInfo()
        {
            string url = "http://localhost:52229/api/Market/ShowBooInfo";
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<BooInfo> list = JsonConvert.DeserializeObject<List<BooInfo>>(s);
            return list;
        }
        #endregion

        #region
        public IActionResult DetialBooAucalAndBoo()
        {
            return View();
        }
        #endregion


        public class LayUi
        {
            public string code { get; set; }
            public string msg { get; set; }
            public string count { get; set; }
            public object data { get; set; }
        }

    }
}