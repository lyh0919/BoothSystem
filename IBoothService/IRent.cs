using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IBoothService
{
    /// <summary>
    /// 租赁
    /// </summary>
   public interface IRent
    {
        //竞拍订单显示
        List<OrderInfo> RentShow(Expression<Func<OrderInfo, bool>> where, Expression<Func<OrderInfo, string>> order, int pageIndex, int pageSize, out int count);

        //添加
        int InsertRent(OrderInfo model);
        //合同显示
        List<ConTastInfo> ConTastShow();
        
    }
}
