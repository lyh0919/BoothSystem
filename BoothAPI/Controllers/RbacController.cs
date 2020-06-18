using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public List<RbacDeptPart> GetDept()
        {

            return null;
        }
        
        //部门修改
        public int UptDept(RbacDeptPart dept)
        {
            return _rbac.UptDept(dept);
        }
    }
}
