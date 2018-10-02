using System;
using System.Collections.Generic;

namespace NewSports.Models
{
    public partial class MemberLogin
    {
        public string Fbname { get; set; }
        public int MemberId { get; set; }

        public MembersTb Member { get; set; }
    }
}
