using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
    public interface IShow
    {


        //分页获取微信会员信息列表
        List<MemberInfoo> ShowWeiXin(int page = 1, int limit = 10);
        
        //查询所有省份 用于绑定第一级下拉 
        List<City> GetSheng();

        //根据省份id 查询该省的城市 用于二级联动
      

        //根据城市id 查询该城市的县 用于三级联动


        //添加微信会员信息
        int AddWx(MemberInfoo m);

        //编辑微信会员信息
        int UpdateWx(MemberInfoo m);

        //根据id删除微信会员信息
        int DelWx(object id);

        //批量删除微信会员信息
        int DelAll(bool isSave = true, params MemberInfoo[] entitys);
    
    }
}
