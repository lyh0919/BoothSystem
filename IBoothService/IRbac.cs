using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IBoothService
{
    public interface IRbac
    {
        //部门
        List<RbacDeptPart> GetDept();

        int AddDept(RbacDeptPart dept);

        int DelDept(object id);

        int UptDept(RbacDeptPart dept, params string[] propertyNames);

        RbacDeptPart GetDeptOne(Expression<Func<RbacDeptPart, bool>> where);


        //角色
        List<RbacRoleInfo> GetRole();

        int AddRole(RbacRoleInfo role);

        int DelRole(object id);

        int UptRole(RbacRoleInfo role);

        RbacRoleInfo GetRoleOne(Expression<Func<RbacRoleInfo, bool>> where);

        //权限反填
        List<RbacPower> GetPower();

        //设置权限
        int AddRolePow(List<RbacPowerAndRole> raps);

        //查询是否有权限
        List<RbacPowerAndRole> GetRolePower(string roleid);


        //成员
        List<RbacAdmin> GetAdmin(Func<RbacAdmin, bool> @where, Func<RbacAdmin, DateTime> order, int pageIndex, int pageSize, out int count);

        int AddAdmin(RbacAdmin role);

        int DelAdmin(object id);

        int UptAdmin(RbacAdmin role);

        RbacAdmin GetAdminOne(Expression<Func<RbacAdmin, bool>> where);


        List<City> GetCity(Expression<Func<City, bool>> where);
    }
}
