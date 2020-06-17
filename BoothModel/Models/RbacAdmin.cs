using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class RbacAdmin
    {
        public Guid Id { get; set; }
        public string AccName { get; set; }
        public string AccNum { get; set; }
        public string AccPass { get; set; }
        public string AccPhone { get; set; }
        public string AccImg { get; set; }
        public Guid? DeptId { get; set; }
        public Guid? RoleId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
    }
}
