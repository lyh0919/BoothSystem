using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IBoothService
{
    public interface IBoothManager
    {
        #region 摊位及摊位详情
        int BoothCount(Expression<Func<BooInfo, bool>> where);

        List<BooInfo> ShowBoo();

        int AddBoo(BooInfo model);

        int DelBoo(object id);

        int UptBoo(BooInfo model,string[] propertyNames);

        //    List<MarketInfo> ShowDetial(object id);

        //List<City> GetCity(Expression<Func<City, bool>> where);

        List<BooInfo> GetBooInfo(Expression<Func<BooInfo, bool>> where);


        List<BooInfo> SearchBoo(Expression<Func<BooInfo, bool>> name);


        List<BooInfo> SearchBooAndMarket(Expression<Func<BooInfo, bool>> name);

        #endregion
        #region  摊位竞拍

        int AddBooAucalInfo(BooAucalnfo model);
        int DelBooAucalInfo(object id);
        int UpdateBooAucal(BooAucalnfo model,string[] propertyNames);
        List<BooAucalnfo> ShowBooAucalInfo();
        List<BooAucalnfo> SearchBooAucal(Expression<Func<BooAucalnfo, bool>> name);
        List<BooAucalnfo> SearchBooAucalId(Expression<Func<BooAucalnfo, bool>> id);
        #endregion


    }
}
