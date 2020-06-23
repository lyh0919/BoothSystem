using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBoothDataAccess
{
   public interface IRentData
    {
        //竞拍订单显示
        List<OrderInfo> RentShow();
        //修改
        int Update(OrderInfo od);
        //添加
        int InsertRent(OrderInfo model);
        //合同显示
        List<ConTastInfo> ConTastShow();
    }
}
