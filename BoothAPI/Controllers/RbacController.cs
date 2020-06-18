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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RbacController : ControllerBase
    {
        private IRbac _rbac;
        public RbacController(IRbac rbac)
        {
            _rbac = rbac;
        }

        //部门添加
        [HttpPost]
        public int AddDept(RbacDeptPart dept)
        {
            return _rbac.AddDept(dept);
        }
        //部门删除
        [HttpDelete]
        public int DelDept(object id)
        {
            return _rbac.DelDept(id);
        }

        //部门显示
        [HttpGet]
        public List<RbacDeptPart> GetDept()
        {

            
            return _rbac.GetDept();
        }

        //部门修改
        [HttpPut]
        public int UptDept(RbacDeptPart dept)
        {
            return _rbac.UptDept(dept);
        }
    }
}
