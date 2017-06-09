using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAmFine.Data
{
    public class UserStatus
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime AtTime { get; set; }

        public string Status { get; set; }

    }
}
