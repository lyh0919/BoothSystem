using BoothModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothAPI.ViewModel
{
    public class DeptPage
    {
        public List<RbacDeptPart> DeptList { get; set; }
        public int Count { get; set; }
    }
}
