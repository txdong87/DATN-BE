using System.Collections.Generic;

namespace Application.DTOs.CaseStudy
{
    public class UpdateCaseStudyDto
    {
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
