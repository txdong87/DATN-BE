using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Casestudy
    {
        public int CaseStudyId { get; set; }
        public int? Patientld { get; set; }
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public int? DoctorId {get; set; }   

        public virtual ICollection<MedicalCdha> MedicalCdhas { get; set; }
        public virtual ICollection<MedicalIndication> MedicalIndications { get; set; }
        public virtual ICollection<MedicalTest> MedicalTests { get; set; }
        public virtual Patient? PatientldNavigation { get; set; }
        public virtual Doctor? DoctorldNavigation { get; set; }
    }
}
