using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.MedicalCdhaCaseStudyDTO
{
    public class AddMedicalCdhaCaseStudyDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int KtvId { get; set; }
        public int CaseStudyId { get; set; }
        public int MedicalCdhaId { get; set; }
    }
}
