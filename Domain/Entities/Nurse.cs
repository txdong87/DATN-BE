using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Nurse
    {
        public int Nurseld { get; set; }
        public int? Userld { get; set; }

        public virtual User? UserldNavigation { get; set; }
    }
}
