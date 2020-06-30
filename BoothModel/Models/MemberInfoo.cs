using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class MemberInfoo
    {
        public Guid Id { get; set; }
        public string MemName { get; set; }
        public string MemWx { get; set; }
        public string MemAddress { get; set; }
        public string MemState { get; set; }
        public string IsAllow { get; set; }
        public string MemPhone { get; set; }
       
    }
}
