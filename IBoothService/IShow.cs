using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
    public interface IShow
    {
        List<RbacDeptPart> GetDept();

        //分页获取微信会员信息列表
        List<MemberInfoo> GetWeiXin(Func<MemberInfoo, bool> @where, Func<MemberInfoo, MemberInfoo> order, int pageIndex, int pageSize, out int count, bool isDesc = false);

        //查询所有省份 用于绑定第一级下拉 
        List<City> GetSheng();

        //根据省份id 查询该省的城市 用于二级联动
      

        //根据城市id 查询该城市的县 用于三级联动


        //添加微信会员信息
        int Add(MemberInfoo entity, bool isSave = true);


        //编辑微信会员信息





        //根据id删除微信会员信息
        int Del(object id, bool isSave = true);


        //批量删除微信会员信息
        int DelAll(bool isSave = true, params MemberInfoo[] entitys);
    
    }
}
