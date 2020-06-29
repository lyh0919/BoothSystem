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
        private IBoothManager _boothManager;
        public RentController(IRent rent, IMarketBll market, IBoothManager boothManager)
        {
            _rent = rent;
            _market = market;
            _boothManager = boothManager;
        }

        //显示
        public OrderPages GetOrder(string orderno, string paystate, int pageindex, int pagesize = 2)
        {
            int count = 0;
            List<OrderInfo> orderlist = new List<OrderInfo>();
            if (orderno == null)
            {
                orderno = "";
            }

            if (paystate != null)//判断是否有效
            {
                orderlist = _rent.GetOrder(u => u.OrderNo.Contains(orderno) & u.PayState == paystate, u => u.OrderNo, pageindex, pagesize, out count);

            }
            else
            {
                orderlist = _rent.GetOrder(u => u.OrderNo.Contains(orderno), u => u.OrderNo, pageindex, pagesize, out count);
            }

            var list = from s in orderlist
                       join a in _boothManager.ShowBooAucalInfo() on s.BooAucaId equals a.Id
                       join b in _boothManager.ShowBoo() on a.BooId equals b.Id
                       join m in _market.ShowMarket() on b.MarkId equals m.Id
                       select new OrderPage()
                       {
                           OrderNo = s.OrderNo,
                           BooNo = b.BooNo,
                           MarkName = m.MarkName,
                           RenPrice = s.RenPrice,
                           CashMoney = s.CashMoney,
                           PayState = s.PayState,
                           CreateTime = b.CreateTime,
                           ZCreateTime = a.CreateTime,
                           ZEndTime = a.EndTime
                       };
            OrderPages orderPages = new OrderPages {OrderList = list.ToList(),Count=count };
            return orderPages;

        }

        public List<ConTastInfo> ShowContastInfo()
        {
            List<ConTastInfo> list = _rent.ShowContastInfo();
            return list;
        }
    }
}
