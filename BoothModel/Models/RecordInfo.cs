using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class RecordInfo
    {
        public Guid Id { get; set; }
        public Guid? AccId { get; set; }
        public string IpAddress { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Record { get; set; }
    }
}
