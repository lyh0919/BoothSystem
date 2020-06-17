using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class RbacRoleInfo
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
    }
}
