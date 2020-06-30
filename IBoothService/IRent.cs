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

        List<ConTastInfo> ShowContastInfo(Expression<Func<ConTastInfo, bool>> id);
    }
}
