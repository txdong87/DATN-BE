using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Doctor
    {
        public Doctor()
        {
            Patients = new HashSet<Patient>();
            Reports = new HashSet<Report>();
        }

        public int Doctorld { get; set; }
        public int Userld { get; set; }
        public string DoctorRole { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
