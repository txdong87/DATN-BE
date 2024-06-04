using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MedicalCdha
    {
        public int Id { get; set; }
        public int? Patientld { get; set; }
        public int? Doctorld { get; set; }
        public int? Ktvld { get; set; }
        public int? CaseStudyId { get; set; }
        public string? ObservationType { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? TimeEstimate { get; set; }
        public string? ImageName { get; set; }
        public string? ImageLink { get; set; }
        public bool? NonDicom { get; set; }

        public virtual Doctor? DoctorldNavigation { get; set; }
        public virtual Ktv? KtvldNavigation { get; set; }
        public virtual Casestudy? CaseStudyIdNavigation { get; set; }
        public virtual Patient? PatientIdNavigation { get; set; }
    }
}
