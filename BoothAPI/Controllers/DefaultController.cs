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
        //获取微信会员信息列表(下拉)
        public List<MemberInfoo> ShowWeiXins()
        {
            return _show.ShowWeiXin();
        }

        [HttpGet]
        //分页获取微信会员信息列表
        public List<MemberInfoo> ShowWeiXin(int page = 1, int limit = 10)
        {
            List<MemberInfoo> list = _show.ShowWeiXin();
            return list.Skip((page-1)*limit).Take(limit).ToList();
        }
        
        //微信会员添加 
        [HttpPost]
        public int Add(MemberInfoo m)
        {
            m.Id = Guid.NewGuid();
            return _show.AddWx(m);
        }

        //根据id删除微信会员信息
        [HttpDelete]
        public int DelWx(Guid ids)
        {
            return _show.DelWx(ids);
        }
        //编辑微信会员信息
        [HttpPost]
        public int UptWx(MemberInfoo m)
        {
            m.Id = Guid.NewGuid();
            return _show.UpdateWx(m);
        }
        //根据id 查询数据 修改
        [HttpGet]
        public MemberInfoo UptWx(Guid ids)
        {
            MemberInfoo memberInfoo = _show.Uptwx(w => w.Id == ids);
            return memberInfoo;
        }

        //查询所有省份 用于绑定第一级下拉 
        [HttpGet]
        public List<City> GetSheng(int id)
        {
         return _show.GetSheng(c => c.PId == id); ;
        }
 
      //批量删除微信会员信息
        [HttpPost]
        public int DelAll(bool isSave = true, params MemberInfoo[] entitys)
        {
             return _show.DelAll(isSave = true, entitys); ;
        }

       

/// <summary>
/// ////////////租户页面/////////////////////////////////////////////////
/// </summary>
/// <param name="page"></param>
/// <param name="limit"></param>
/// <returns></returns>
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
            m.Id = Guid.NewGuid();
            return _show.AddUser(m);
        }

        //根据id删除租户信息
        [HttpDelete]
        public int Delus(Guid id)
        {
            return _show.Delus(id);
         }
        [HttpPost]
        //编辑租户信息
        public int UptUs(UserInfo m)
        {
            m.Id = Guid.NewGuid();
            return _show.UptUs(m);
        }
       [HttpGet]
        //根据id 查询数据 修改
        public UserInfo Uptus(Guid ids)
        {
            UserInfo userin = _show.Uptus(w => w.Id == ids);
            return userin;
        }





        //批量删除租户信息
        [HttpPost]
        public int DelAllUs(bool isSave = true, params UserInfo[] entitys)
        {
            return _show.DelAllUs(isSave = true, entitys); ;
        }

       

    }
}