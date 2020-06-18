using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class BooInfo
    {
        public Guid Id { get; set; }
        public string BooTitle { get; set; }
        public string BooNo { get; set; }
        public Guid? MarkId { get; set; }
        public int? BooArea { get; set; }
        public int? BooLen { get; set; }
        public int? BooWid { get; set; }
        public byte[] BooLabel { get; set; }
        public decimal? BooRent { get; set; }
        public int? BooDead { get; set; }
        public Guid? LessId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
    }
}
