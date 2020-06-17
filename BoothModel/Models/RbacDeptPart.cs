using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class RbacDeptPart
    {
        public Guid Id { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
    }
}
