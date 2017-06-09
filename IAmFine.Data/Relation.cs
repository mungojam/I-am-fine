using System;
using System.Collections.Generic;
using System.Text;

namespace IAmFine.Data
{
    public class Relation
    {
        public User Employee { get; set; }
        public User Helper { get; set; }

        public string Relationship { get; set; }
    }
}
