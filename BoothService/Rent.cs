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


        //显示一条
        public List<OrderInfo> GetOrderAll()
        {
            var server = this.CreateService<OrderInfo>();
            return server.GetAll().ToList();



        }

        //合同
        public ConTastInfo GetContastOne(Expression<Func<ConTastInfo, bool>> where)
        {
            var server = this.CreateService<ConTastInfo>();
            return server.FirstOrDefault(where);



        }

    }
}
