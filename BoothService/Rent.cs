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
    public class Rent: Base, IRent
    {
        public Rent(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
        }

        //显示
        public List<OrderInfo> GetOrder(Expression<Func<OrderInfo, bool>> where, Expression<Func<OrderInfo, string>> order, int pageIndex, int pageSize, out int count)
        {
            var server = this.CreateService<OrderInfo>();
            return server.Where(where, order, pageIndex, pageSize, out count).ToList();

        }

        //实现合同
        public List<ConTastInfo> ShowContastInfo(Expression<Func<ConTastInfo, bool>> id)
        {
            var server = this.CreateService<ConTastInfo>();
            return server.Where(id).ToList();
        }
    }
}
