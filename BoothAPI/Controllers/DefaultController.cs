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
    [EnableCors("MyCors")]
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


        //分页获取微信会员信息列表
        [HttpGet]
        public List<MemberInfoo> GetWeiXin(Func<MemberInfoo, bool> @where, Func<MemberInfoo, MemberInfoo> order, int pageIndex, int pageSize, out int count, bool isDesc = false)
        {
            var list = _show.GetWeiXin(@where, order, pageIndex, pageSize, out count, isDesc);
            return list;
        }

        //查询所有省份 用于绑定第一级下拉 
        [HttpGet]
        public List<City> GetSheng()
        {
            var list = _show.GetSheng();
            return list;
        }

        //根据省份id 查询该省的城市 用于二级联动
        [HttpGet]

        //根据城市id 查询该城市的县 用于三级联动
        [HttpGet]

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