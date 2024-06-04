using System;
using System.Collections.Generic;

namespace API.Entities
{
    public partial class Casestudy
    {
        public int CaseStudyId { get; set; }
        public int? Patientld { get; set; }
        public string? PatientName { get; set; }
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? DiagnosticClinical { get; set; }
        public string? ClinicalDiagnosis { get; set; }
        public string? ListCdha { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;

        public virtual Patient? PatientldNavigation { get; set; }
    }
}
