using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace IAmFine.Data
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Collection<UserStatus> UserStatuses { get; set; }

    }
}
