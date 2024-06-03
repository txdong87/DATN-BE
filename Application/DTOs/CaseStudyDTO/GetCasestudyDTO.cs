using System.Collections.Generic;

namespace Application.DTOs.CaseStudy
{
    public class GetCaseStudyDto
    {
        public int CaseStudyId { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public List<int> MedicalCdhaIds { get; set; }
        public List<int> MedicalIndicationIds { get; set; }
        public List<int> MedicalTestIds { get; set; }
    }
}
