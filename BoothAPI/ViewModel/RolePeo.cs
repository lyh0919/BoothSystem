using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothAPI.ViewModel
{
    public class RolePeo
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
        public int PeopleCount { get; set; }
    }
}
