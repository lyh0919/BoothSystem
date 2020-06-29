using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothAPI.ViewModel
{
    public class OrderPage
    {
        public Guid Id { get; set; }
        public string OrderNo { get; set; }
        public Guid? BooAucaId { get; set; }
        public Guid? UserId { get; set; }
        public decimal? RenPrice { get; set; }
        public decimal? CashMoney { get; set; }
        public string Teancy { get; set; }
        public DateTime? CreateTime { get; set; }

        public string PayState { get; set; }
        public string OrderState { get; set; }


        public DateTime? ZCreateTime { get; set; }
        public DateTime? ZEndTime { get; set; }

        public Guid? BooId { get; set; }



        public string BooTitle { get; set; }
        public string BooNo { get; set; }
        

        public string MarkName { get; set; }
    }
}
