using System;
using System.Collections.Generic;

namespace NewSports.Models
{
    public partial class MemberSports
    {
        public int SportsMemberId { get; set; }
        public int MemberId { get; set; }
        public int? SportsId { get; set; }

        public MembersTb Member { get; set; }
        public SportsTb Sports { get; set; }
    }
}
