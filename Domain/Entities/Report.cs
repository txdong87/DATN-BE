using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int? PatientId { get; set; }
        public int CaseStudyId { get; set; }
        public int? DoctorId { get; set; }
        public string? Image { get; set; }
        public int? State { get; set; }
        public string? Conclusion { get; set; }
        public int? KtvId { get; set; }
        public string? Diagnostic { get; set; }

        public virtual Doctor? DoctorIdNavigation { get; set; }
        public virtual Patient? PatientIdNavigation { get; set; }
        public virtual KTV? KTVIdNavigation { get; set; }
        public virtual Casestudy Casestudy { get; set; }
    }
}
