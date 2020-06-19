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
        #region 部门
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
        public List<RbacDeptPart> GetDept()
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.GetAll().ToList();
        }
        //部门修改
        public int UptDept(RbacDeptPart dept)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.Update(dept);
        }
        #endregion

        #region 角色
        //显示
        public List<RbacRoleInfo> GetRole()
        {
            var server = this.CreateService<RbacRoleInfo>();
            return server.GetAll().ToList();
        }
        //添加
        public int AddRole(RbacRoleInfo role)
        {
            var server = this.CreateService<RbacRoleInfo>();
            return server.Add(role);
        }
        //删除
        public int DelRole(object id)
        {
            var server = this.CreateService<RbacRoleInfo>();
            return server.Delete(id);

        }
        //修改
        public int UptRole(RbacRoleInfo role)
        {
            var server = this.CreateService<RbacRoleInfo>();
            return server.Update(role);
        }
        #endregion



    }
}
