using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Doctor
    {
        public Doctor()
        {
            Casestudies = new HashSet<Casestudy>();

        }

        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string DoctorRole { get; set; }

        public virtual ICollection<Casestudy> Casestudies { get; set; }
    }
}
