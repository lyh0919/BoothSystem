using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Linq.Expressions;

namespace BoothService
{
    public class MarketBll : Base, IMarketBll
    {

        public MarketBll(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {

        }
        #region 添加市场
        public int AddMarket(MarketInfo model)
        {
            var server = this.CreateService<MarketInfo>();
            return server.Add(model);
        }

        public int DelMarket(object id)
        {
            var server = this.CreateService<MarketInfo>();
            return server.Delete(id);
        }



        public List<MarketInfo> ShowMarket()
        {
            var server = this.CreateService<MarketInfo>();
            return server.GetAll().ToList();
        }

        public int UptMarket(MarketInfo model)
        {
            var server = this.CreateService<MarketInfo>();
            return server.Update(model);
        }



        public List<City> GetCity(Expression<Func<City, bool>> where)
        {
            var server = this.CreateService<City>();
            return server.Where(where).ToList();
        }

        public List<MarketInfo> GetMarketInfo(Expression<Func<MarketInfo, bool>> where)
        {
            var server = this.CreateService<MarketInfo>();
            return server.Where(where).ToList();
        }

        public List<MarketInfo> SearchMarket(Expression<Func<MarketInfo, bool>> name)
        {
            var server = this.CreateService<MarketInfo>();
            return server.Where(name).ToList();
        }



        public List<UserInfo> ShowUserInfo()
        {
            var server = this.CreateService<UserInfo>();
            return server.GetAll().ToList();
        }

     
        #endregion
    }
}
