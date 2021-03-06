﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothAPI.ViewModel
{
    public class BooAucalInfoAndUser
    {
        public Guid Id { get; set; }
        public Guid? BooId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? CashMoney { get; set; }
        public decimal? StartMoney { get; set; }
        public decimal? MarkUpMoney { get; set; }
        public decimal? ResMoney { get; set; }
        public DateTime? DefTime { get; set; }
        public string WinnerUser { get; set; }
        public decimal? FinishPrice { get; set; }
        public string OrderState { get; set; }
        public string CashMoneyState { get; set; }
        public string BooAucaState { get; set; }
        public string BooTitle { get; set; }
        public Guid Uid { get; set; }
        public string UserName { get; set; }

        public int Count { get; set; }
    }
}
