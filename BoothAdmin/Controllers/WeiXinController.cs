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
         //添加微信会员视图
        public IActionResult Addwx()
        {
            return View();
        }
        //添加的方法
        public int addw(MemberInfoo m)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/Default/Add";
            m.Id = Guid.NewGuid();
            string stu = JsonConvert.SerializeObject(m);
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(stu);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") {CharSet="utf-8" };
            message = client.PostAsync(url,content).Result;
            string s = message.Content.ReadAsStringAsync().Result;
            return Convert.ToInt32(s);

        }


        //查询所有省份 用于绑定第一级下拉 
        [HttpGet]
        public IActionResult GetSheng()
        {
            return View();
        }

        //根据省份id 查询该省的城市 用于二级联动


        //根据城市id 查询该城市的县 用于三级联动



        //修改微信会员信息
        public IActionResult Updwx()
        {
            return View();
        }
        //删除微信会员信息
        public ActionResult Delwx()
        {
            return View();
        }

        //租户列表视图
        public IActionResult ShowUs()
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
        //添加租户信息视图
        public IActionResult Addus()
        {
            return View();
        }
        //添加租户信息方法
        public int Addu(UserInfo m)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/Default/AddUser";
            m.Id = Guid.NewGuid();
            string stu = JsonConvert.SerializeObject(m);
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(stu);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            message = client.PostAsync(url, content).Result;
            string s = message.Content.ReadAsStringAsync().Result;
           return Convert.ToInt32(s); ;
        }


        //修改租户信息
        public IActionResult Updus()
        {
            return View();
        }
        //删除租户信息
        public IActionResult Delus()
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