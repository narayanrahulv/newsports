using System;
using System.Collections.Generic;

namespace NewSports.Models
{
    public partial class MembersTb
    {
        public MembersTb()
        {
            MemberLogin = new HashSet<MemberLogin>();
            MemberSports = new HashSet<MemberSports>();
        }

        public int MemberId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ICollection<MemberLogin> MemberLogin { get; set; }
        public ICollection<MemberSports> MemberSports { get; set; }
    }
}
