using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace BoothService
{
  public  class MarketBll:Base,IMarketBll
    {
        public MarketBll(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {

        }

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

        //public List<MarketInfo> ShowMarket(int page = 1, int limit = 10)
        //{
        //    List<MarketInfo> list = null;
        //    using (SqlConnection conn=new SqlConnection("server=192.168.1.130;database=BoothManage;uid=sa;pwd=123456;"))
        //    {
        //        string sql = "select * from MarketInfo";
        //   list=    conn.Query<MarketInfo>(sql).ToList();
        //    }
        //    list = list.Skip((page - 1) * limit).Take(limit).ToList();
        //    return list;
        //}
    }
}
