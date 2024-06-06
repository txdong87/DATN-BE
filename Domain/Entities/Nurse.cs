using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Nurse
    {
        public int NurseId { get; set; }
        public int UserId { get; set; }

        public virtual User? UserIdNavigation { get; set; }
    }
}
