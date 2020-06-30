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

        //编辑微信会员信息
        public IActionResult Updwx()
        {
            return View();
        }

        //根据会员名称和账户查询
        public ActionResult SeleWx(string name="",string wx="")
        {
            string url = "http://localhost:52229/api/Default/SeleWx?name="+name+"&wx="+wx;
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<MemberInfoo> list = JsonConvert.DeserializeObject<List<MemberInfoo>>(s);
           if(list.Count==0)
            {
            return Json(new LayUi { code = "1", msg = "没有找到相关记录，请更换查询条件", count = 0.ToString(), data = "" });
            }
           else
            {
                return Json(new LayUi { code = "0", msg = "", count = list.Count.ToString(), data = list });
             }
       }


        /// <summary>
        /// /////////////////租户页面/////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

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

        //编辑微信会员信息
        public IActionResult Updus()
        {
            return View();
        }

        //根据名称查询租户
        public ActionResult SeleUs(string name = "")
        {
            string url = "http://localhost:52229/api/Default/SeleUs?name=" + name ;
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponse = client.GetAsync(url).Result;
            string s = httpResponse.Content.ReadAsStringAsync().Result;
            List<UserInfo> list = JsonConvert.DeserializeObject<List<UserInfo>>(s);
            if (list.Count == 0)
            {
                return Json(new LayUi { code = "1", msg = "没有找到相关记录，请更换查询条件", count = 0.ToString(), data = "" });
            }
            else
            {
                return Json(new LayUi { code = "0", msg = "", count = list.Count.ToString(), data = list });
            }
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