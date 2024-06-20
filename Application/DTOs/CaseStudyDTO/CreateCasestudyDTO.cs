using Application.DTOs.PatientDTO;
using Application.DTOs.PrescriptionDTO;
using System;

namespace Application.DTOs.CaseStudy
{
    public class CreateCaseStudyDto
    {
        //public PatientDto Patient { get; set; }
        public int patientId { get; set; }
        //public ReportDto Report { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
