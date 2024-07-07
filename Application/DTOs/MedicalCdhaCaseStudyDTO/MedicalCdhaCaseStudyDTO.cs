using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{

    public class MedicalCdhaCaseStudyDto
    {
        public int Id { get; set; }
        public int? KtvId { get; set; }
        public int? CaseStudyId { get; set; }
        public int? MedicalCdhaId { get; set; }
        public int? ReportId { get; set; }

        public string Conclusion { get; set; }
        public string Description { get; set; }
        public string? ImageName { get; set; }
        public string? ImageLink { get; set; }
    }
}
