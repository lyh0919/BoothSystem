using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
    public interface IRbac
    {
        List<RbacDeptPart> GetDept();

        int AddDept(RbacDeptPart dept);

        int DelDept(object id);

        int UptDept(RbacDeptPart dept);
    }
}
