using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class OrderInfo
    {
        public Guid Id { get; set; }
        public string OrderNo { get; set; }
        public Guid? Mark_Id { get; set; }
        public Guid? BooAucaId { get; set; }
        public Guid? UserId { get; set; }
        public decimal? RenPrice { get; set; }
        public decimal? CashMoney { get; set; }
        public string Teancy { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string PayState { get; set; }
        public string OrderState { get; set; }
    }
}
