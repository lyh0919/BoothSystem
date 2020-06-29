using BoothModel.Models;
using Dapper;
using IBoothDataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoothDataAccess
{
   public class RentData:IRentData
    {
        //private readonly string _connectionString;
        ////Data Source = LAPTOP - IGQ004KI\ZHU;Initial Catalog = BoothManage; Integrated Security = True

        //public RentData(IConfiguration configuration)
        //{
        //    _connectionString = configuration.GetSection("ConnectionStrings")["BoothConnection"];
        //}

        // SqlConnection conn = new SqlConnection("Data Source = LAPTOP - IGQ004KI\\ZHU;Initial Catalog = BoothManage; Integrated Security = True");
        /// <summary>
        /// 合同
        /// </summary>
        /// <returns></returns>
        public List<ConTastInfo> ConTastShow()
        {
            using (SqlConnection conn = new SqlConnection("Data Source =LAPTOP - IGQ004KI\\ZHU;Initial Catalog = BoothManage; Integrated Security = True"))
            {
                return conn.Query<ConTastInfo, OrderInfo, ConTastInfo>
                    ("select * from ConTastInfo a inner join OrderInfo b on a.Oid=b.Id",
                       (ct, od) => { return ct; }, splitOn: "Oid").ToList();
            };

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="od"></param>
        /// <returns></returns>
        public int InsertRent(OrderInfo od)
        {

            using (SqlConnection conn = new SqlConnection("Data Source = LAPTOP - IGQ004KI\\ZHU;Initial Catalog = BoothManage; Integrated Security = True"))
            {

                return conn.Execute("insert  into OrderInfo values ('" + od.OrderNo + "','" + od.Mark_Id + "','" + od.BooAucaId + "','" + od.UserId + "','" + od.RenPrice + "','" + od.CashMoney + "','" + od.Teancy + "','" + od.CreateTime + "'," +
                    "'" + od.PayState + "',)");

            };
        }
        /// <summary>
        /// 竞拍订单
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> RentShow()
        {

            using (SqlConnection conn = new SqlConnection("Data Source =.;Initial Catalog = BoothManages; uid=sa;pwd=123456;"))
            {
                return conn.Query<OrderInfo>("select a.OrderNo,a.Mark_Id,a.BooAucaId,a.UserId,a.RenPrice,a.CashMoney,a.Teancy,a.CreateTime,a.EndTime,a.PayState,a.OrderState from OrderInfo a inner join BooAucalnfo b on a.BooAucaId=b.Id inner join BooInfo c on b.BooId =c.Id inner join MarketInfo d on c.Mark_Id=d.Id").ToList();
            };


        }
        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="od"></param>
        /// <returns></returns>
        public int Update(OrderInfo od)
        {

            using (SqlConnection conn = new SqlConnection("Data Source = LAPTOP - IGQ004KI\\ZHU;Initial Catalog = BoothManage; Integrated Security = True"))
            {
                return conn.Execute("update  OrderInfo set   OrderNo='" + od.OrderNo + "',Mark_Id='" + od.Mark_Id + "',BooAucaId='" + od.BooAucaId + "',UserId='" + od.UserId + "',RenPrice='" + od.RenPrice + "',CashMoney='" + od.CashMoney + "',Teancy='" + od.Teancy + "',CreateTime='" + od.CreateTime + "',PayState='" + od.PayState + "',)");

            }
        }
    }
}
