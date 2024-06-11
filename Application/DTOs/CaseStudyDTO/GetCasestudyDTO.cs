using System;

namespace Application.DTOs.CaseStudy
{
    public class GetCaseStudyDto
    {
        public int CaseStudyId { get; set; }
        public int PatientId { get; set; }
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? DoctorId { get; set; }
        public string? PatientName { get; set; } // Assuming this property already exists

        // New properties added
        public string? Address { get; set; }
        public int? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        public string? PatientCode { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
