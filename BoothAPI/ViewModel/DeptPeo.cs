using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothAPI.ViewModel
{
    public class DeptPeo
    {
        public Guid Id { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string IsEnable { get; set; }
        public int PeopleCount { get; set; }
    }
}
