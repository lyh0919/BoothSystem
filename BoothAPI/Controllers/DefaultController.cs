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
    public class DefaultController : ControllerBase
    {
        private IShow _show;
        public DefaultController(IShow show)
        {
            _show = show;
        }

        [HttpGet]
        //分页获取微信会员信息列表
        public List<MemberInfoo> ShowWeiXin(int page = 1, int limit = 10)
        {
            List<MemberInfoo> list = _show.ShowWeiXin();
            return list.Skip((page-1)*limit).Take(limit).ToList();
        }

        //查询所有省份 用于绑定第一级下拉 
        [HttpGet]
        public List<City> GetSheng()
        {
           return _show.GetSheng(); 
        }

        //根据省份id 查询该省的城市 用于二级联动
       

        //根据城市id 查询该城市的县 用于三级联动
       

        //微信会员添加 
        [HttpPost]
        public int Add(MemberInfoo m)
        {
           return _show.AddWx(m);
        }

        //根据id删除微信会员信息
        [HttpPost]
        public int Del(object id)
        {
            return _show.DelWx(id);
        }

        //批量删除微信会员信息
        [HttpPost]
        public int DelAll(bool isSave = true, params MemberInfoo[] entitys)
        {
             return _show.DelAll(isSave = true, entitys); ;
        }

        //编辑微信会员信息
        [HttpPost]
        public int UptWx(MemberInfoo m)
        {
            return _show.UpdateWx(m);
        }


        [HttpGet]
        //分页获取租户信息列表
        public List<UserInfo> ShowUser(int page = 1, int limit = 10)
        {
            List<UserInfo> list = _show.ShowUser();
            return list.Skip((page - 1) * limit).Take(limit).ToList();
        }

        //添加租户信息 
        [HttpPost]
        public int AddUser(UserInfo m)
        {
            return _show.AddUser(m);
        }

        //根据id删除租户信息
        [HttpPost]
        public int Delus(object id)
        {
            return _show.Delus(id);
        }

        //批量删除租户信息
        [HttpPost]
        public int DelAllUs(bool isSave = true, params UserInfo[] entitys)
        {
            return _show.DelAllUs(isSave = true, entitys); ;
        }

        //编辑租户信息
        [HttpPost]
        public int UptUs(UserInfo m)
        {
            return _show.UptUs(m);
        }




    }
}