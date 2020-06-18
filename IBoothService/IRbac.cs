using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
    public interface IRbac
    {
        List<RbacDeptPart> GetDept(Func<RbacDeptPart, bool> @where, Func<RbacDeptPart, RbacDeptPart> order, int pageIndex, int pageSize, out int count, bool isDesc = false);

        int AddDept(RbacDeptPart dept);

        int DelDept(object id);

        int UptDept(RbacDeptPart dept);
    }
}
