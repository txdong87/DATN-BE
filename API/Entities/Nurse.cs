using System;
using System.Collections.Generic;

namespace API.Entities
{
    public partial class Nurse
    {
        public int Nurseld { get; set; }
        public int? Userld { get; set; }
        public string? NurseName { get; set; }

        public virtual User? UserldNavigation { get; set; }
    }
}
