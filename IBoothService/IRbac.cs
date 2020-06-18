using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IBoothService
{
    public interface IRbac
    {
        List<RbacDeptPart> GetDept(Expression<Func<RbacDeptPart, bool>> @where, Expression<Func<RbacDeptPart, RbacDeptPart>> order, int pageIndex, int pageSize, out int count, bool isDesc = false);



        int AddDept(RbacDeptPart dept);

        int DelDept(object id);

        int UptDept(RbacDeptPart dept);
    }
}
