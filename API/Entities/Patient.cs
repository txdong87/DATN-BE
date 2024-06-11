using System;
using System.Collections.Generic;

namespace API.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Casestudies = new HashSet<Casestudy>();
            MedicalCdhas = new HashSet<MedicalCdha>();
            MedicalIndications = new HashSet<MedicalIndication>();
            MedicalTests = new HashSet<MedicalTest>();
            Reports = new HashSet<Report>();
        }

        public int Patientld { get; set; }
        public string? PatientName { get; set; }
        public string? Address { get; set; }
        public int? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        public int? Roomld { get; set; }
        public virtual ICollection<Casestudy> Casestudies { get; set; }
        public virtual ICollection<MedicalCdha> MedicalCdhas { get; set; }
        public virtual ICollection<MedicalIndication> MedicalIndications { get; set; }
        public virtual ICollection<MedicalTest> MedicalTests { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
