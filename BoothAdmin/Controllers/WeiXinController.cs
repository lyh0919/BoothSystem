using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BoothModel.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BoothAdmin.Controllers
{
    public class WeiXinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //显示微信会员信息
        public ActionResult ShowWeiXin(int page = 1, int limit = 10)
        {
            string url = "http://localhost:52229/api/Default/ShowWeiXin";
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MemberInfoo> list = JsonConvert.DeserializeObject<List<MemberInfoo>>(s);

            int PageCount = (list == null || list.Count == 0) ? 0 : list.Count;
            int c = (int)Math.Ceiling((decimal)PageCount / limit);
            ViewBag.parper = (page <= 1) ? 1 : page - 1;
            ViewBag.pagenext = page >= c ? c : page + 1;
            ViewBag.pahelast = c;
            return Json(new LayUi { code = "0", msg = "", count = PageCount.ToString(), data = list });
           
        }
         //添加微信会员信息
        public ActionResult Addwx()
        {
            return View();
        }

        //修改微信会员信息
        public ActionResult Updwx()
        {
            return View();
        }
        //删除微信会员信息
        public ActionResult Delwx()
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