using BoothModel.Models;
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

        //显示所有省份 用于绑定第一级下拉 
        public List<City> GetSheng()
        {
            var service = this.CreateService<City>();
            return service.GetAll().ToList();
        }

        //根据省份id 查询该省的城市 用于二级联动


        //根据城市id 查询该城市的县 用于三级联动


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



        //批量删除微信会员信息
        public int DelAll(bool isSave = true, params MemberInfoo[] entitys)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Delete(entitys);
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
       


        //修改租户
        public int UptUs(UserInfo m)
        {
            var service = this.CreateService<UserInfo>();
            return service.Update(m);
        }
        //根据id编辑微信租户信息
       
        public List<UserInfo> Uptus(Expression<Func<UserInfo, bool>> where)
        {
            var service = this.CreateService<UserInfo>();
            return service.Where(where).ToList();
        }
        //批量删除租户信息
        public int DelAllUs(bool isSave = true, params UserInfo[] entitys)
        {
            var service = this.CreateService<UserInfo>();
            return service.Delete(entitys);
        }

       

       
    }
}
