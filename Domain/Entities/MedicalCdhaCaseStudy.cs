using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalCdhaCaseStudy
    {   
        public int Id { get; set; } 
        public int? DoctorId { get; set; }
        public int? KtvId { get; set; }
        public int? CaseStudyId { get; set; }
        public int? MedicalCdhaId { get; set; }
        public int ReportId { get; set; }

        public string Conlusion { get; set; } //kết luận

        public string Description { get; set; } //mô tả
        public string? ImageName { get; set; }
        public string? ImageLink { get; set; }
        public virtual Report? Report { get; set; }
        public virtual Doctor? DoctorIdNavigation { get; set; }
        public virtual KTV? KtvIdNavigation { get; set; }
        public virtual Casestudy? CaseStudyIdNavigation { get; set; }
        public virtual MedicalCdha? MedicalCdhaIdNavigation { get; set; }
    }
}
