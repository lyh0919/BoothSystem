using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class ConTastInfo
    {
        public Guid Id { get; set; }
        public string ConNo { get; set; }
        public Guid? Oid { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
