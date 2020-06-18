using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BoothAPI.ViewModel;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RbacController : ControllerBase
    {
        private IRbac _rbac;
        public RbacController(IRbac rbac)
        {
            _rbac = rbac;
        }

        //部门添加
        public int AddDept(RbacDeptPart dept)
        {
            return _rbac.AddDept(dept);
        }
        //部门删除
        public int DelDept(object id)
        {
            return _rbac.DelDept(id);
        }

        //部门显示
        public DeptPage GetDept(Expression<Func<RbacDeptPart, bool>> where, Expression<Func<RbacDeptPart, RbacDeptPart>> order,int pageindex,int pagesize)
        {

            int count = 0;
            List<RbacDeptPart> list = _rbac.GetDept(where, order, pageindex, pagesize, out count);
            DeptPage deptPage = new DeptPage() { DeptList = list,Count=count};
            return deptPage;
        }
        
        //部门修改
        public int UptDept(RbacDeptPart dept)
        {
            return _rbac.UptDept(dept);
        }
    }
}
