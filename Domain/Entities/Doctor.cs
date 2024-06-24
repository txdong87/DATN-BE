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
            Casestudies = new HashSet<Casestudy>();

        }

        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string DoctorRole { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Casestudy> Casestudies { get; set; }
        public virtual ICollection<MedicalCdhaCaseStudy> MedicalCdhas { get; set; }
    }
}
