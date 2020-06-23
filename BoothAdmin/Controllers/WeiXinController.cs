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

      
        //根据id删除微信会员信息
        [HttpPost]
        public int Delwx(Guid id)
        {
           HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/default/DelWx?ids=" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });
            message = client.DeleteAsync(url).Result;
            string s = message.Content.ReadAsStringAsync().Result;
             return Convert.ToInt32(s);
  }

        //查询所有省份 用于绑定第一级下拉 

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
      

        //修改租户信息
        public IActionResult Updus()
        {
            return View();
        }
        [HttpPost]
        //根据id删除租户信息
        public int Delus(Guid id)
        {
            HttpResponseMessage message = null;
            string url = "http://localhost:52229/api/default/Delus?id=" + id;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") { CharSet = "utf-8" });
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