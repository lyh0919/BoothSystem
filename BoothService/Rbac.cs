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
    public class Rbac : Base, IRbac
    {
        public Rbac(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
        }
        //部门添加
        public int AddDept(RbacDeptPart dept)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.Add(dept);
        }
        //部门删除
        public int DelDept(object id)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.Delete(id);
        }

        //部门显示
        public List<RbacDeptPart> GetDept(Expression<Func<RbacDeptPart, bool>> @where, Expression<Func<RbacDeptPart, RbacDeptPart>> order, int pageIndex, int pageSize, out int count, bool isDesc = false)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.Where(@where, order, pageIndex, pageSize,out count).ToList();
        }
        //部门修改
        public int UptDept(RbacDeptPart dept)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.Update(dept);
        }
    }
}
