using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class MedicalCdhaDTO
    {
        public int Id { get; set; }
        public string CdhaName { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? TimeEstimate { get; set; }
        public string? ImageName { get; set; }
        public string? ImageLink { get; set; }
        public string? result { get; set; }

        public virtual Doctor? DoctorIdNavigation { get; set; }
        public virtual KTV? KtvIdNavigation { get; set; }
        public virtual Casestudy? CaseStudyIdNavigation { get; set; }
        public virtual Patient? PatientIdNavigation { get; set; }
    }
}
