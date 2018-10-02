using System;
using System.Collections.Generic;

namespace NewSports.Models
{
    public partial class SportsTb
    {
        public SportsTb()
        {
            MemberSports = new HashSet<MemberSports>();
        }

        public int SportsId { get; set; }
        public string SportsName { get; set; }

        public ICollection<MemberSports> MemberSports { get; set; }
    }
}
