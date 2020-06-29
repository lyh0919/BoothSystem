using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothAPI.ViewModel;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private IRent _rent;
        private IMarketBll _market;
        public RentController(IRent rent, IMarketBll market)
        {
            _rent = rent;
            _market = market;
        }

        //显示
        [HttpGet]
        public List<OrderPage> GetAdmin(string orderno, string stateid, int pageindex, int pagesize = 2)
        {
            int count = 0;
            List<OrderInfo> orderlist = new List<OrderInfo>();
            if (orderno == null)
            {
                orderno = "";
            }

            if (stateid != "undefined")//判断是否有效
            {
                orderlist = _rent.RentShow(u => u.OrderNo.Contains(orderno) & u.PayState == stateid, u => u.OrderNo, pageindex, pagesize, out count);

            }
            else
            {
                orderlist = _rent.RentShow(u => u.OrderNo.Contains(""), u => u.OrderNo, pageindex, pagesize, out count);
            }

            //成员显示
            var list = from s in orderlist
                       join d in _market.ShowMarket() on s.DeptId equals d.Id
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
            OrderPage memPage = new OrderPage { Members = list.ToList(), Count = count };

            return memPage;
        }
    }
}