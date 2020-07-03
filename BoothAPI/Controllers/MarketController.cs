using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoothAPI.ViewModel;
using BoothModel;
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

        //摊位数
        [HttpGet]
        public int BoothCount(string isenable)
        {
            if (isenable == null)
            {
                isenable = "";
            }
            return _boothManager.BoothCount(b => b.IsEnable.Contains(isenable));
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
            string[] propertyNames = new string[] { };
            propertyNames = ReflectHelper.GetProperties(model);
            return _marketBll.UptMarket(model, propertyNames);
          
        }


        //显示所有数据
        public List<MarketInfo> ShowMarket()
        {
            List<MarketInfo> list = _marketBll.ShowMarket();

            return list;
        }

        /// <summary>
        ///显示详情数据 编辑反填数据
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
                if (name !=null || isable=="")
                {
                    list = _marketBll.SearchMarket(s => s.MarkName.Contains(name));
                }
                else if (isable != null || name == "")
                {
                    list = _marketBll.SearchMarket(s => s.IsEnable.Equals(isable));
                }
                else
                {
                    list = _marketBll.SearchMarket(s => s.MarkName.Contains(name) && s.IsEnable.Equals(isable));
                }
            }

            return list;
        }


        //三级联动调用此方法
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
        [HttpPost]
        public int UpdateBooth(BooInfo model)
        {
          
         
            model.UpdateTime = DateTime.Now;
            string[] propertyNames = new string[] { };
            propertyNames = ReflectHelper.GetProperties(model);
            return _boothManager.UptBoo(model,propertyNames);
        }


        //显示所有数据  三表联查 摊位表 市场表 用户列表
        public List<BooAndMarket> ShowBooth()
        {
            List<BooInfo> list = _boothManager.ShowBoo();

            var lists = (from s in list
                         join a in _marketBll.ShowMarket() on s.MarkId equals a.Id
                         join b in _marketBll.ShowUserInfo() on s.LessId equals b.Id
                         select new BooAndMarket
                         {
                             Id=s.Id,
                             MarkId=a.Id,
                             CreateTime=s.CreateTime,
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
        ///显示详情数据  编辑反填数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BooInfo> ShowBooDetial(Guid id)
        {
            List<BooInfo> list = _boothManager.GetBooInfo(p => p.Id == id);
            return list;
        }




        //地摊查询
        public List<BooAndMarket> SearchBooInfo(string name,string isable,string marketid)
        {
            List<BooAndMarket> list = ShowBooth();
            if (name != null && isable != null && marketid != null)
            {
                list = list.Where(s => s.BooTitle.Contains(name) && s.IsEnable.Equals(isable) && s.MarkId.Equals(marketid)).ToList();
            }
           if(name =="")
            {
                if (isable=="" ||marketid=="")
                {
                    list.Where(s => s.IsEnable.Equals(isable) || s.MarkId.Equals(marketid)).ToList();
                }
                else
                {
                    list.Where(s => s.IsEnable.Equals(isable) && s.MarkId.Equals(marketid)).ToList();
                }
            }
           if(isable=="")
            {
                if (name==""||marketid=="")
                {
                    list.Where(s => s.BooTitle.Contains(name) || s.MarkId.Equals(marketid)).ToList();
                }
                else
                {
                    list.Where(s => s.BooTitle.Contains(name) && s.MarkId.Equals(marketid)).ToList();
                }
                
            }
            if (marketid=="")
            {
                if (name == "" || isable == "")
                {
                    list.Where(s => s.BooTitle.Contains(name) || s.IsEnable.Equals(isable)).ToList();
                }
                else
                {
                    list.Where(s => s.BooTitle.Contains(name) || s.IsEnable.Equals(isable)).ToList();
                }
               
            }
           
            return list;
        }
        //调用了查询详情的方法


        #endregion
        #region  出租明细历史   DetialBoothAndUser
            //显示详情
        public List<BooAndMarket> ShowDetialBoothAndUser(Guid id)
        {
            List<BooAndMarket> list = ShowBooth();
            list = list.Where(s => s.Id.Equals(id)).ToList();
            return list;
        }

        //查询
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


        #region 摊位竞拍管理

        public int AddBooAcucal(BooAucalnfo model)
        {
            model.Id = Guid.NewGuid();
            model.WinnerUser = "4af377cc-5f26-48cd-b3f6-4ed7950ba26b";
            model.FinishPrice = 4000;
            model.OrderState = "1";
            model.CashMoneyState = "1";
            model.BooAucaState = "1";
            return _boothManager.AddBooAucalInfo(model);
        }
        //修改
        public int UpdateBooAucal(BooAucalnfo model)
        {
         
            string[] propertyNames = new string[] { };
            propertyNames = ReflectHelper.GetProperties(model);
            return _boothManager.UpdateBooAucal(model, propertyNames);
           
        }

        public int DeleteBooAucal(Guid id)
        {
            return _boothManager.DelBooAucalInfo(id);
        }

        //三表联查 摊位表 市场表 摊位竞拍
        public List<BooAucalInfoAndUser> ShowAll()
        {
            List<BooAucalnfo> list = _boothManager.ShowBooAucalInfo();
            var lists = (from s in list
                         join a in _boothManager.ShowBoo() on s.BooId equals a.Id
                         join b in _marketBll.ShowUserInfo() on a.LessId equals b.Id
                         select new BooAucalInfoAndUser
                         {
                             Id=s.Id,
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
        //显示摊位表 为了三表联查
        public List<BooInfo> ShowBooInfo()
        {
            List<BooInfo> list = _boothManager.ShowBoo();
            return list;
        }

        //编辑反填数据
        public List<BooAucalnfo> ShowDetialOne(Guid id)
        {
            List<BooAucalnfo> list = _boothManager.SearchBooAucalId(s => s.Id.Equals(id));
            var lists = (from s in list
                         select new BooAucalnfo
                         {
                             Id = s.Id,
                             BooId = s.BooId,
                             CreateTime = Convert.ToDateTime(string.Format("{0:yyyy/MM/dd}", s.CreateTime)),
                             EndTime = Convert.ToDateTime(string.Format("{0:yyyy/MM/dd}", s.EndTime)),
                             CashMoney = s.CashMoney,
                             MarkUpMoney = s.MarkUpMoney,
                             StartMoney = s.StartMoney,
                             ResMoney = s.ResMoney,
                             DefTime = Convert.ToDateTime(string.Format("{0:yyyy/MM/dd}", s.DefTime))
                         }).ToList();

            return lists;
        }

        //查询数据
        public List<BooAucalnfo> SearchBooAucal(string name, string isable)
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


        #region  竞拍明细
        public List<BooAucalInfoAndUser> ShowOrder(Guid id)
        {
            List<BooAucalInfoAndUser> list = ShowAll();
            list=list.Where(s => s.Id.Equals(id)).ToList();
            return list;

        }

        public List<BooAucalInfoAndUser> SearchOrder(string name)
        {
            List<BooAucalInfoAndUser> list = ShowAll();
            list = list.Where(s => s.UserName.Contains(name)).ToList();
            return list;
        }
        #endregion 

    }
}