using Application.DTOs;
using Application.DTOs.PatientDTO;
using Application.DTOs.PrescriptionDTO;
using System;

namespace Application.DTOs.CaseStudy
{
    public class GetCaseStudyDto
    {
        public int CaseStudyId { get; set; }
        public int PatientId { get; set; }
        public int? ReportCount { get; set; }
        public string Conclusion { get; set; }
        public string Diagnostic { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? DoctorId { get; set; }

        public PatientDto Patient { get; set; }
        public List<ReportDTO> Reports { get; set; }
        //public ReportDto Report { get; set; }
        public List<MedicalCdhaDTO> MedicalCdhas { get; set; }
        public List<PrescriptionDto> Prescriptions { get; set; }
    }
}
