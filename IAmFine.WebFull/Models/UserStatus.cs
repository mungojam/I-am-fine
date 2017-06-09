using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IAmFine.Data;

namespace IAmFine.WebFull.Models
{
    public class UserStatus
    {
        public User User { get; set; }
        public string LatestStatus { get; set; }
        public DateTime AtTime { get; set; }
    }
}