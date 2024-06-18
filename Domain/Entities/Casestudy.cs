﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Casestudy
    {
        public Casestudy()
        {
            MedicalCdhas = new HashSet<MedicalCdha>();
            Prescriptions = new HashSet<Prescription>();
        }

        public int CaseStudyId { get; set; }
        public int patientId { get; set; }
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public int? DoctorId { get; set; }

        public virtual ICollection<MedicalCdha> MedicalCdhas { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        
        public virtual Patient? PatientIdNavigation { get; set; }
        public virtual Doctor? DoctorIdNavigation { get; set; }
    }
}
