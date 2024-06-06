using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Image { get; set; }
        public int? State { get; set; }
        public string? Conclusion { get; set; }
        public int? KtvId { get; set; }
        public string? Diagnostic { get; set; }

        public virtual Doctor? DoctorIdNavigation { get; set; }
        public virtual Patient? PatientIdNavigation { get; set; }
    }
}
