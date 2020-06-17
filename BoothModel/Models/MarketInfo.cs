using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class MarketInfo
    {
        public Guid Id { get; set; }
        public string MarkName { get; set; }
        public string MarkPhone { get; set; }
        public string MarkAccName { get; set; }
        public string MarkAddress { get; set; }
        public int? MarkSortId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
    }
}
