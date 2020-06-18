using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
