using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IShow _show;
        public DefaultController(IShow show)
        {
            _show = show;
        }

        [HttpGet]
        public List<RbacDeptPart> Get()
        {
            var list = _show.GetDept();
            return list;
        }


        

        //微信会员添加 
        [HttpPost]
        public int Add(MemberInfoo entity, bool isSave = true)
        {
            var list = _show.Add(entity);
            return list;
        }

        //根据id删除微信会员信息
        [HttpPost]
        public int Del(object id, bool isSave = true)
        {
            var list = _show.Del(id);
            return list;
        }

        //批量删除微信会员信息
        [HttpPost]
        public int DelAll(bool isSave = true, params MemberInfoo[] entitys)
        {
            var list = _show.DelAll(isSave = true, entitys);
            return list;
        }




    }
}