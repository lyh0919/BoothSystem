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
        //微信会员视图
        public IActionResult Index()
        {
            return View();
        }
        //租户列表视图
        public IActionResult ShowUs()
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


        //显示租户信息
        public ActionResult ShowUser(int page = 1, int limit = 10)
        {
            string url = "http://localhost:52229/api/Default/ShowUser";
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<UserInfo> list = JsonConvert.DeserializeObject<List<UserInfo>>(s);

            int PageCount = (list == null || list.Count == 0) ? 0 : list.Count;
            int c = (int)Math.Ceiling((decimal)PageCount / limit);
            ViewBag.parper = (page <= 1) ? 1 : page - 1;
            ViewBag.pagenext = page >= c ? c : page + 1;
            ViewBag.pahelast = c;
            return Json(new LayUi { code = "0", msg = "", count = PageCount.ToString(), data = list });

        }
        //添加租户信息
        public ActionResult Addus()
        {
            return View();
        }

        //修改租户信息
        public ActionResult Updus()
        {
            return View();
        }
        //删除租户信息
        public ActionResult Delus()
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