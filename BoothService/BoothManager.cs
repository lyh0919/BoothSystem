using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BoothService
{
    public class BoothManager : Base, IBoothManager
    {
        public BoothManager(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {

        }
        #region 添加摊位
        public int AddBoo(BooInfo model)
        {
            var server = this.CreateService<BooInfo>();
            return server.Add(model);
        }


        public int DelBoo(object id)
        {
            var server = this.CreateService<BooInfo>();
            return server.Delete(id);
        }



        public List<BooInfo> GetBooInfo(Expression<Func<BooInfo, bool>> where)
        {
            var server = this.CreateService<BooInfo>();
            return server.Where(where).ToList();
        }

        public List<BooInfo> SearchBoo(Expression<Func<BooInfo, bool>> name)
        {
            var server = this.CreateService<BooInfo>();
            return server.Where(name).ToList();
        }

        public List<BooInfo> SearchBooAndMarket(Expression<Func<BooInfo, bool>> name)
        {
            var server = this.CreateService<BooInfo>();
            return server.Where(name).ToList();
        }



        public List<BooInfo> ShowBoo()
        {
            var server = this.CreateService<BooInfo>();
            return server.GetAll().ToList();
        }



        public int UptBoo(BooInfo model)
        {
            var server = this.CreateService<BooInfo>();
            return server.Update(model);
        }
        #endregion

        #region 摊位竞拍管理
        public int AddBooAucalInfo(BooAucalnfo model)
        {
            var server = this.CreateService<BooAucalnfo>();
            return server.Add(model);
        }

        public List<BooAucalnfo> ShowBooAucalInfo()
        {
            var server = this.CreateService<BooAucalnfo>();
            return server.GetAll().ToList();
        }

        public int UpdateBooAucal(BooAucalnfo model)
        {
            var server = this.CreateService<BooAucalnfo>();
            return server.Update(model);
        }
        public List<BooAucalnfo> SearchBooAucal(Expression<Func<BooAucalnfo, bool>> name)
        {
            var server = this.CreateService<BooAucalnfo>();
            return server.Where(name).ToList();
        }

        public List<BooAucalnfo> SearchBooAucalId(Expression<Func<BooAucalnfo, bool>> id)
        {
            var server = this.CreateService<BooAucalnfo>();
            return server.Where(id).ToList();
        }
        public int DelBooAucalInfo(object id)
        {
            var server = this.CreateService<BooAucalnfo>();
            return server.Delete(id);
        }
        #endregion
    }
}
