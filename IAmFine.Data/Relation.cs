using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IAmFine.Data
{
    public class Relation
    {
        [Key]
        public User Employee { get; set; }

        [Key]
        public User Helper { get; set; }

        [Key]
        public string Relationship { get; set; }

        public int Priority { get; set; }
    }
}
