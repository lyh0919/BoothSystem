using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothAPI.ViewModel;
using BoothModel.Models;
using IBoothService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoothAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private IMarketBll _marketBll;
     
        private IBoothManager _boothManager;
        public MarketController(IMarketBll marketBll, IBoothManager boothManager)
        {
            this._marketBll = marketBll;
          
            this._boothManager = boothManager;
        }
        #region  添加市场

        //添加方法
        [HttpPost]
        public int AddMarket(MarketInfo model)
        {
            return _marketBll.AddMarket(model);
        }

        //删除方法
        public int DelMarket(Guid id)
        {
            return _marketBll.DelMarket(id);
        }

        //修改某一条数据
        public int UpdateMarket(MarketInfo model)
        {
            model.UpdateTime = DateTime.Now;
            model.CreateTime = DateTime.Now;

            return _marketBll.UptMarket(model);
        }


        //显示所有数据
        public List<MarketInfo> ShowMarket()
        {
            List<MarketInfo> list = _marketBll.ShowMarket();

            return list;
        }

        /// <summary>
        ///显示详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MarketInfo> ShowDetial(Guid id)
        {
            List<MarketInfo> list = _marketBll.GetMarketInfo(p => p.Id == id);
            return list;
        }

        //调用的查询方法
        public List<MarketInfo> SearchMarket(string name, string isable)
        {
            List<MarketInfo> list = null;
            if (name == null && isable == null)
            {
                list = _marketBll.ShowMarket();
            }
            else
            {
                list = _marketBll.SearchMarket(s => s.MarkName.Contains(name) & s.IsEnable.Equals(isable));
            }

            return list;
        }



        public List<City> GetCity(int id)
        {
            return _marketBll.GetCity(c => c.PId == id);
        }


        #endregion



        #region 地摊
        //添加方法
        [HttpPost]
        public int AddBooth(BooInfo model)
        {
            return _boothManager.AddBoo(model);
        }

        //删除方法
        public int DelBooth(Guid id)
        {
            return _boothManager.DelBoo(id);
        }

        //修改某一条数据
        public int UpdateBooth(BooInfo model)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            return _boothManager.UptBoo(model);
        }


        //显示所有数据
        public List<BooAndMarket> ShowBooth()
        {
            List<BooInfo> list = _boothManager.ShowBoo();

            var lists = (from s in list
                         join a in _marketBll.ShowMarket() on s.MarkId equals a.Id
                         join b in _marketBll.ShowUserInfo() on s.LessId equals b.Id
                         select new BooAndMarket
                         {
                             BooTitle = s.BooTitle,
                             BooNo = s.BooNo,
                             MarkName = a.MarkName,
                             BooRent = s.BooRent,
                             BooDead = s.BooDead,
                             UserName = b.UserName,
                             UpdateTime = s.UpdateTime,
                             IsEnable = s.IsEnable
                         }).ToList();
            return lists;
        }

        /// <summary>
        ///显示详情数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BooInfo> ShowBooDetial(Guid id)
        {
            List<BooInfo> list = _boothManager.GetBooInfo(p => p.Id == id);
            return list;
        }

        //调用的查询方法
        public List<BooInfo> SearchBooInfo(string name, string isable)
        {
            List<BooInfo> list = _boothManager.SearchBoo(s => s.BooTitle.Contains(name) & s.IsEnable.Equals(isable));
            return list;
        }
        //调用了查询详情的方法
        public List<BooAndMarket> DetialBooAndMarket(string name)
        {
            List<BooAndMarket> list = ShowBooth();
            list.Where(s => s.MarkName.Contains(name) || s.MarkPhone.Equals(name));
            return list;

        }

        #endregion


        #region 显示用户

        public List<UserInfo> ShowUserInfo()
        {
            List<UserInfo> list = _marketBll.ShowUserInfo();
            return list;
        }
        #endregion


        #region 出租明细历史

        public int AddBooAcucal(BooAucalnfo model)
        {

            return _boothManager.AddBooAucalInfo(model);
        }

        public int UpdateBooAucal(BooAucalnfo model)
        {
            return _boothManager.UpdateBooAucal(model);
        }

        public int DeleteBooAucal(Guid id)
        {
            return _boothManager.DelBooAucalInfo(id);
        }

        public List<BooAucalInfoAndUser> ShowAll()
        {
            List<BooAucalnfo> list = _boothManager.ShowBooAucalInfo();
            var lists = (from s in list
                         join a in _boothManager.ShowBoo() on s.BooId equals a.Id
                         join b in _marketBll.ShowUserInfo() on a.LessId equals b.Id
                         select new BooAucalInfoAndUser
                         {
                             BooTitle = a.BooTitle,
                             CreateTime = s.CreateTime,
                             EndTime = s.EndTime,
                             Count = _marketBll.ShowUserInfo().Count,
                             UserName = b.UserName,
                             FinishPrice = s.FinishPrice,
                             OrderState = s.OrderState,
                             CashMoneyState = s.CashMoneyState,
                             BooAucaState = s.BooAucaState,
                             BooId = a.Id
                         }).ToList();
            return lists;
        }
        public List<BooInfo> ShowBooInfo()
        {
            List<BooInfo> list = _boothManager.ShowBoo();
            return list;
        }

        public List<BooAucalnfo> ShowDetialOne(Guid id)
        {
            List<BooAucalnfo> list = _boothManager.SearchBooAucalId(s => s.Id.Equals(id));
            return list;
        }

        public List<BooAucalnfo> SearchBooAucal(string name, string isable, string markid)
        {
            List<BooAucalnfo> list = null;
            if (name != null)
            {
                list = _boothManager.SearchBooAucalId(s => s.WinnerUser.Contains(name));
            }
            else if (isable != null)
            {
                list = _boothManager.SearchBooAucalId(s => s.OrderState.Contains(isable));
            }
            else
            {
                list = _boothManager.SearchBooAucalId(s => s.OrderState.Contains(isable) && s.OrderState.Equals(isable));
            }
            return list;
        }

        #endregion
    
  } 
}