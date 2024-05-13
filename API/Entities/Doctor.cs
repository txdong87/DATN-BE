using System;
using System.Collections.Generic;

namespace API.Entities
{
    public partial class Doctor
    {
        public Doctor()
        {
            MedicalCdhas = new HashSet<MedicalCdha>();
            MedicalTests = new HashSet<MedicalTest>();
            Patients = new HashSet<Patient>();
            Reports = new HashSet<Report>();
        }

        public int Doctorld { get; set; }
        public int? Userld { get; set; }
        public string? DoctorName { get; set; }

        public virtual User? UserldNavigation { get; set; }
        public virtual ICollection<MedicalCdha> MedicalCdhas { get; set; }
        public virtual ICollection<MedicalTest> MedicalTests { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
