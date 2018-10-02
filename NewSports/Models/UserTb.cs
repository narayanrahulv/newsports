using System;
using System.Collections.Generic;

namespace NewSports.Models
{
    public partial class UserTb
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
    }
}
