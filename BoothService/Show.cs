using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoothService
{
    public class Show:Base,IShow
    {
        public Show(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
        }

        public List<RbacDeptPart> GetDept()
        {
            var service = this.CreateService<RbacDeptPart>();
            return service.GetAll().ToList();
        }

        //分页获取微信会员信息列表
        public List<MemberInfoo>GetWeiXin(Func<MemberInfoo, bool> @where, Func<MemberInfoo, MemberInfoo> order, int pageIndex, int pageSize, out int count, bool isDesc = false)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Where<MemberInfoo>(@where, order, pageIndex,pageSize,out count, isDesc).ToList();
        }

        //查询所有省份 用于绑定第一级下拉 
        public List<City> GetSheng()
        {
            var service = this.CreateService<City>();
            return service.GetAll().ToList();
        }

        //根据省份id 查询该省的城市 用于二级联动


        //根据城市id 查询该城市的县 用于三级联动


        //微信会员添加 
        public int Add(MemberInfoo entity, bool isSave = true)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Add(entity);
        }

        //根据id删除微信会员信息
        public int Del(object id, bool isSave = true)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Delete(id);
        }

        //批量删除微信会员信息
        public int DelAll(bool isSave = true, params MemberInfoo[] entitys)
        {
            var service = this.CreateService<MemberInfoo>();
            return service.Delete(entitys);
        }
    }
}
