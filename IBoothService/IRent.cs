using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothService
{
    /// <summary>
    /// 租赁
    /// </summary>
   public interface IRent
    {
        //竞拍订单显示
        List<OrderInfo> RentShow();
        //修改
        int Update(OrderInfo id);
        //添加
        int InsertRent(OrderInfo model);
        //合同显示
        List<ConTastInfo> ConTastShow();
        
    }
}
