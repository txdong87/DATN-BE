using System;

namespace Application.DTOs.CaseStudy
{
    public class CreateCaseStudyDto
    {
        public int? PatientId { get; set; }
        public string? Reason { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? DoctorId { get; set; }
        public string? Diagnostic { get; set; }
        public string? Status { get; set; }
    }
}
