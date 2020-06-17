using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class RbacPowerAndRole
    {
        public Guid Id { get; set; }
        public string PowerId { get; set; }
        public string RoleId { get; set; }
    }
}
