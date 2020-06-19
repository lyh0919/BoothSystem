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

        int UptDept(RbacDeptPart dept);


        //角色
        List<RbacRoleInfo> GetRole();

        int AddRole(RbacRoleInfo role);

        int DelRole(object id);

        int UptRole(RbacRoleInfo role);

        //权限反填
        List<RbacPower> GetPower();

    }
}
