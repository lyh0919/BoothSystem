﻿using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BoothService
{
    public class Show:Base,IShow
    {
        public Show(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
        }

       
        //分页获取微信会员信息列表
        public List<MemberInfoo> ShowWeiXin()
        {
            var service = this.CreateService<MemberInfoo>();
            return service.GetAll().ToList();
        }
        //微信会员添加 
        public int AddWx(MemberInfoo m)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Add(m);
        }
        //根据id删除微信会员信息
        public int DelWx(Guid ids)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Delete(ids,true);
        }
        //编辑微信会员信息
        public int UpdateWx(MemberInfoo m)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Update(m);
        }
        //根据id查询
        public MemberInfoo Uptwx(Expression<Func<MemberInfoo, bool>> where)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.FirstOrDefault(where);
        }

        //显示所有省份  
        public List<City> GetSheng(Expression<Func<City, bool>> where)
        {
            var service = this.CreateService<City>();
            return service.Where(where).ToList();
        }

    
        //批量删除微信会员信息
        public int DelAll(List<MemberInfoo> entitys)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Delete(entitys);
        }

        //根据会员名称和账户查询
         public List<MemberInfoo> SeleWx(Expression<Func<MemberInfoo, bool>> where)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Where(where).ToList();
        }



        /// <summary>
        /// /////////租户页//////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        //用户数
        public int UserCount(Expression<Func<UserInfo, bool>> where)
        {
            var server = this.CreateService<UserInfo>();
            return server.Count(where);
        }

        //分页获取租户信息列表
        public List<UserInfo> ShowUser()
        {
            var service = this.CreateService<UserInfo>();
            return service.GetAll().ToList();
        }
        //添加租户信息 
        public int AddUser(UserInfo m)
        {
            var service = this.CreateService<UserInfo>();
            return service.Add(m);
        }
         //根据id删除租户信息
        public int Delus(object id)
        {
            var service = this.CreateService<UserInfo>();
            return service.Delete(id);
        }
        //修改租户信息
        public int UptUs(UserInfo m)
        {
            var service = this.CreateService<UserInfo>();
            return service.Update(m);
        }
        //根据id编辑微信租户信息
       public UserInfo Uptus(Expression<Func<UserInfo, bool>> where)
        {
            var service = this.CreateService<UserInfo>();
            return service.FirstOrDefault(where);
        }
        //批量删除租户信息
        public int DelAllUs(List<UserInfo> entitys)
        {
            var service = this.CreateService<UserInfo>();
            return service.Delete(entitys);
        }
       
        //显示所有省份  
        public List<City> GetCity(Expression<Func<City, bool>> where)
        {
            var service = this.CreateService<City>();
            return service.Where(where).ToList();
        }

        //根据名称查询租户信息
        public List<UserInfo> SeleUs(Expression<Func<UserInfo, bool>> where)
        {
            var service = this.CreateService<UserInfo>();
            return service.Where(where).ToList();
        }




    }
}
