using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PatientDTO
    {
        public string? PatientName { get; set; }

        public string? Address { get; set; }
        public int? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        //public string? patientCode { get; set; }
        public DateTime? createdAt{ get; set; }

        //// Assuming you also want to include r nmelated collections in the DTO
        //public ICollection<CasestudyDTO>? Casestudies { get; set; }
        //public ICollection<MedicalCdhaDTO>? MedicalCdhas { get; set; }
        //public ICollection<MedicalIndicationDTO>? MedicalIndications { get; set; }
        //public ICollection<MedicalTestDTO>? MedicalTests { get; set; }
        //public ICollection<ReportDTO>? Reports { get; set; }
    }
}
