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
    /// <summary>
    /// 租赁
    /// </summary>
    public class Rent :Base,IRent
    {
        public Rent(IRepositoryFactory repositoryFactory, IBoothManageContext mydbcontext) : base(repositoryFactory, mydbcontext)
        {
           
        }

        public List<ConTastInfo> ConTastShow()
        {
            throw new NotImplementedException();
        }

        //添加
        public int InsertRent(OrderInfo model)
        {
            var rent = this.CreateService<OrderInfo>();
            return rent.Add(model);

        }
        //显示
        public List<OrderInfo> RentShow(Expression<Func<OrderInfo, bool>> where, Expression<Func<OrderInfo, string>> order, int pageIndex, int pageSize, out int count)
        {
            var rent = this.CreateService<OrderInfo>();
            return rent.Where(where,order,pageIndex,pageSize,out count).ToList();
        }


      
    }
}
