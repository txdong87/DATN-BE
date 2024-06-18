using Application.DTOs.PrescriptionDTO;
using System;

namespace Application.DTOs.CaseStudy
{
    public class CreateCaseStudyDto
    {
        public int PatientId { get; set; }
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? DoctorId { get; set; }
        public List<CreateCaseStudyDto> MedicalCdhas { get; set; }
        public List<CreatePrescriptionDto> Prescriptions { get; set; }
    }
}
