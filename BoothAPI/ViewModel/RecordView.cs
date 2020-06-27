using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoothAPI.ViewModel
{
    public class RecordView
    {
        public Guid Id { get; set; }
        public Guid AccId { get; set; }
        public string IpAddress { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Record { get; set; }

        public string AccName { get; set; }
    }
}
