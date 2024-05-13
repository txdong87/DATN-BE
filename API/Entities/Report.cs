using System;
using System.Collections.Generic;

namespace API.Entities
{
    public partial class Report
    {
        public int Reportld { get; set; }
        public int? Patientld { get; set; }
        public string? PatientName { get; set; }
        public int? Doctorld { get; set; }
        public string? DoctorName { get; set; }
        public string? Image { get; set; }
        public int? State { get; set; }
        public string? Conclusion { get; set; }
        public int? Ktvld { get; set; }
        public string? Diagnostic { get; set; }

        public virtual Doctor? DoctorldNavigation { get; set; }
        public virtual Patient? PatientldNavigation { get; set; }
    }
}
