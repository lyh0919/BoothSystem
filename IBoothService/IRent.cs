using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IBoothService
{
    public interface IRent
    {
        //显示
        List<OrderInfo> GetOrder(Expression<Func<OrderInfo, bool>> @where, Expression<Func<OrderInfo, string>> order, int pageIndex, int pageSize, out int count);
        //显示一条
        List<OrderInfo> GetOrderAll();
        //合同显示
        ConTastInfo GetContastOne(Expression<Func<ConTastInfo, bool>> where);
    }
}
