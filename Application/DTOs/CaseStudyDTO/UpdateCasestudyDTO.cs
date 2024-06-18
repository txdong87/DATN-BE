using System.Collections.Generic;

namespace Application.DTOs.CaseStudy
{
    public class UpdateCaseStudyDto
    {
        public string? Report { get; set; }
        public int? ReportCount { get; set; }
        public string? Conclusion { get; set; }
        public string? Diagnostic { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
