using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
   public interface IMarketBll
    {
        List<MarketInfo> ShowMarket();
      
        int AddMarket(MarketInfo model);

        int DelMarket(object id);

        int UptMarket(MarketInfo model);


    }
}
