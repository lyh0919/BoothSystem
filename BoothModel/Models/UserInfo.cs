using System;
using System.Collections.Generic;

namespace BoothModel.Models
{
    public partial class UserInfo
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserPhone { get; set; }
        public Guid? MemerId { get; set; }
        public string UserAddress { get; set; }
        public string UserState { get; set; }
        public string UserImg { get; set; }
    }
}
