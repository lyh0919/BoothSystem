using BoothModel.Models;
using IBoothDataAccess;
using IBoothService;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<OrderInfo> RentShow()
        {
            var rent = this.CreateService<OrderInfo>();
            return rent.GetAll().ToList();
        }
        //修改
        public int Update(OrderInfo id)
        {
            var rent = this.CreateService<OrderInfo>();
            return rent.Update(id);
        }

      
    }
}
