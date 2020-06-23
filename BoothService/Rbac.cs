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
        public int UptDept(RbacDeptPart dept, params string[] propertyNames)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.Update(dept, propertyNames);
        }
        //获取数据反填
        public RbacDeptPart GetDeptOne(Expression<Func<RbacDeptPart, bool>> where)
        {
            var server = this.CreateService<RbacDeptPart>();
            return server.FirstOrDefault(where);
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
        //获取数据反填
        public RbacRoleInfo GetRoleOne(Expression<Func<RbacRoleInfo, bool>> where)
        {
            var server = this.CreateService<RbacRoleInfo>();
            return server.FirstOrDefault(where);
        }
        #endregion

        //权限反填
        public List<RbacPower> GetPower()
        {
            var server = this.CreateService<RbacPower>();
            return server.GetAll().ToList();
        }

        //设置权限
        public int AddRolePow(List<RbacPowerAndRole> raps)
        {
            var server = this.CreateService<RbacPowerAndRole>();
            return server.Add(raps);
        }
        //获取角色对应的权限
        public List<RbacPowerAndRole> GetRolePower(string roleid)
        {
            var server = this.CreateService<RbacPowerAndRole>();
            var raps = server.GetAll().ToList();
            var raplist = from s in raps where s.RoleId.Equals(roleid) select s;
            return raplist.ToList();
        }

        #region 成员
        //显示
        public List<RbacAdmin> GetAdmin(Func<RbacAdmin, bool> @where, Func<RbacAdmin, DateTime> order, int pageIndex, int pageSize, out int count)
        {
            var server = this.CreateService<RbacAdmin>();
            return server.Where(where,order, pageIndex, pageSize, out count).ToList();


            //if (deptId == "")
            //{
            //    return (from s in admin where s.AccName.Contains(accName) select s).ToList();
            //}
            //else
            //{
            //    return (from s in admin where s.AccName.Contains(accName) & s.DeptId.Equals(deptId) select s).ToList();
            //}

        }
        //添加
        public int AddAdmin(RbacAdmin admin)
        {
            var server = this.CreateService<RbacAdmin>();
            return server.Add(admin);
        }
        //删除
        public int DelAdmin(object id)
        {
            var server = this.CreateService<RbacAdmin>();
            return server.Delete(id);

        }
        //修改
        public int UptAdmin(RbacAdmin admin)
        {
            var server = this.CreateService<RbacAdmin>();
            return server.Update(admin);
        }
        //获取数据反填
        public RbacAdmin GetAdminOne(Expression<Func<RbacAdmin, bool>> where)
        {
            var server = this.CreateService<RbacAdmin>();
            return server.FirstOrDefault(where);
        }
        #endregion

        /// <summary>
        /// 联动
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<City> GetCity(Expression<Func<City, bool>> where)
        {
            var server = this.CreateService<City>();
            return server.Where(where).ToList();
        }

    }
}
