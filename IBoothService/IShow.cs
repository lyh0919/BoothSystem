using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IBoothService
{
    public interface IShow
    {


        //分页获取微信会员信息列表
        List<MemberInfoo> ShowWeiXin();
        //添加微信会员信息
        int AddWx(MemberInfoo m);
        //根据id删除微信会员信息
        int DelWx(Guid ids);
        //查询所有省份
        List<City> GetSheng(Expression<Func<City, bool>> where);

        //编辑微信会员信息
        int UpdateWx(MemberInfoo m);
        //根据id查询
        MemberInfoo Uptwx(Expression<Func<MemberInfoo, bool>> where);

        //批量删除微信会员信息
        int DelAll(List<MemberInfoo> entitys);

        //根据微信名称和账户查询
        List<MemberInfoo> SeleWx(Expression<Func<MemberInfoo, bool>> where);



        /// <summary>
        /// ///////租户页面/////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>

        //分页获取租户信息列表
        List<UserInfo> ShowUser();
         //添加租户信息
        int AddUser(UserInfo m);
        //根据id删除租户信息
        int Delus(object id);
        //查询所有省份
        List<City> GetCity(Expression<Func<City, bool>> where);
        //编辑租户信息
        int UptUs(UserInfo m);
        //根据id查询
        UserInfo Uptus(Expression<Func<UserInfo, bool>> where);

         //批量删除租户信息
        int DelAllUs(List<UserInfo> entitys);

        //根据名称查询租户
        List<UserInfo> SeleUs(Expression<Func<UserInfo, bool>> where);

    }
}
