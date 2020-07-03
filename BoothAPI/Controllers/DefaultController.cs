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
        //用户数
        [HttpGet]
        public int UserCount(string datetime)
        {
            int flag = 0;
            
            if (datetime == null)//全部
            {
                datetime = "";
                flag = _show.UserCount(b => b.UserState.Contains(datetime));
            }
            else if (datetime=="本月")//本月
            {
                flag = _show.UserCount(b => b.CreateTime.Month.Equals(DateTime.Now.Month) & b.CreateTime.Year.Equals(DateTime.Now.Year));
            }
            else if(datetime=="今天")//今天
            {
                flag = _show.UserCount(b => b.CreateTime.Day==DateTime.Now.Day & b.CreateTime.Month == DateTime.Now.Month & b.CreateTime.Year == DateTime.Now.Year);
            }
            else//昨天
            {
                flag = _show.UserCount(b => b.CreateTime.Day == (DateTime.Now.Day)-1 & b.CreateTime.Month == DateTime.Now.Month & b.CreateTime.Year == DateTime.Now.Year);
            }


            return flag;
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

        //查询所有省份  
        [HttpGet]
        public List<City> GetSheng(int id)
        {
         return _show.GetSheng(c => c.PId == id); ;
        }

        //批量删除微信会员信息
        [HttpGet]
        public int DelAll(string noList)
        {
            
            string[] id = noList.TrimEnd(',').Split(',');

            List<MemberInfoo> entitys = new List<MemberInfoo>();
 
            foreach (var item in id)
            {
               entitys.Add(_show.Uptwx(m => m.Id.ToString().Equals(item)));
            }
             return _show.DelAll(entitys); 
        }
        //根据微信名称和账户查询
        [HttpGet]
        public List<MemberInfoo> SeleWx(string name,string wx)
        {
            return _show.SeleWx(c => c.MemName.Contains(name)&c.MemWx.Contains(wx)); 
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

        //查询所有省份  
        [HttpGet]
        public List<City> GetCity(int id)
        {
            return _show.GetCity(c => c.PId == id); ;
        }
        //批量删除租户信息
        [HttpGet]
        public int DelAllUs(string noList)
        {  
            string[] id = noList.TrimEnd(',').Split(',');
            List<UserInfo> entitys = new List<UserInfo>();
            foreach (var item in id)
            {
                entitys.Add(_show.Uptus(m => m.Id.ToString().Equals(item)));
            }
            return _show.DelAllUs(entitys); 
        }
       //根据名称查询租户
        [HttpGet]
        public List<UserInfo> SeleUs(string name)
        {
            return _show.SeleUs(c =>c.UserName.Contains(name));
        }

    }
}