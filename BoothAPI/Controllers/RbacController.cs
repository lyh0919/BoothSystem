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
        #region 部门
        //部门添加
        [HttpPost]
        public int AddDept(RbacDeptPart dept)
        {
            dept.Id = Guid.NewGuid();
            dept.CreateTime = DateTime.Now;
            dept.UpdateTime = DateTime.Now;
            dept.IsEnable = "1";
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
            dept.UpdateTime = DateTime.Now;
            return _rbac.UptDept(dept);
        }
        #endregion
        
        #region 角色
        //角色添加
        [HttpPost]
        public int AddRole(RbacRoleInfo role)
        {
            role.Id = Guid.NewGuid();
            role.CreateTime = DateTime.Now;
            role.UpdateTime = DateTime.Now;
            role.IsEnable = "1";
            return _rbac.AddRole(role);
        }
        //角色删除
        [HttpDelete]
        public int DelRole(object id)
        {
            return _rbac.DelDept(id);
        }

        //角色显示
        [HttpGet]
        public List<RbacRoleInfo> GetRole()
        {
            return _rbac.GetRole();
        }

        //角色修改
        [HttpPut]
        public int UptRole(RbacRoleInfo role)
        {
            role.UpdateTime = DateTime.Now;
            return _rbac.UptRole(role);
        }
        #endregion

        //权限反填
        [HttpGet]
        public List<RbacPower> GetPower()
        {
            return _rbac.GetPower();
        }
        //设置权限
        [HttpGet]
        public int AddRolePow(string roleId, string powId)
        {
            string[] pow = powId.Split(',');
            List<RbacPowerAndRole> raps = new List<RbacPowerAndRole>();
            foreach (var rp in _rbac.GetRolePower(roleId)) 
            {
                foreach (var item in pow)
                {
                    if (!rp.PowerId.Equals(item))
                    {
                        RbacPowerAndRole rap = new RbacPowerAndRole();
                        rap.Id = Guid.NewGuid();
                        rap.RoleId = roleId;
                        rap.PowerId = item;
                        raps.Add(rap);
                    }
                }
            }
            
            return _rbac.AddRolePow(raps);
        }

        //反填已有的权限
        [HttpGet]
        public List<RbacPowerAndRole> GetRolePowById(string roleId)
        {

            return _rbac.GetRolePower(roleId);
        }

        #region 成员
        //显示
        [HttpGet]
        public MemPage GetAdmin(string accName,string deptId,int pageindex,int pagesize =2)
        {
            int count = 0;
            List<RbacAdmin> memlist = new List<RbacAdmin>();
            if (accName == null)
            {
                accName = "";
            }
            if (deptId!= "undefined")
            {
                memlist = _rbac.GetAdmin(u => u.AccName.Contains(accName) & u.DeptId.ToString() == deptId, u => (DateTime)u.CreateTime, pageindex, pagesize, out count);

            }
            else
            {
                memlist = _rbac.GetAdmin(u => u.AccName.Contains(accName), u => (DateTime)u.CreateTime, pageindex, pagesize, out count);
            }


            var list = from s in memlist
                       join d in _rbac.GetDept() on s.DeptId equals d.Id
                       select new Member() 
                       {
                           Id = s.Id,
                           AccNum = s.AccNum,
                           AccName = s.AccName,
                           AccPass = s.AccPass,
                           AccPhone = s.AccPhone,
                           DeptName = d.DeptName,
                           CreateTime = s.CreateTime,
                           UpdateTime = s.UpdateTime,
                           IsEnable = s.IsEnable
                       };
            MemPage memPage = new MemPage { Members=list.ToList(),Count=count};

            return memPage;
        }
        //添加
        [HttpPost]
        public int AddAdmin(RbacAdmin admin)
        {
            admin.Id = Guid.NewGuid();
            admin.CreateTime = DateTime.Now;
            admin.UpdateTime = DateTime.Now;
            return _rbac.AddAdmin(admin);
        }
        //删除
        [HttpDelete]
        public int DelAdmin(object id)
        {
            return _rbac.DelAdmin(id);

        }
        //修改
        [HttpPut]
        public int UptAdmin(RbacAdmin admin)
        {
            return _rbac.UptAdmin(admin);
        }
        #endregion

    }
}
