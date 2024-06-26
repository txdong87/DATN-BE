﻿using Application.DTOs.CaseStudy;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
namespace Application.Interfaces
{
    public interface ICaseStudyService
    {
        Task<GetCaseStudyDto> GetCaseStudyByIdAsync(int caseStudyId);
        Task<IEnumerable<GetCaseStudyDto>> GetAllCaseStudiesAsync();
        Task<Casestudy> AddCaseStudyAsync(CreateCaseStudyDto createCaseStudyDto);
        Task UpdateCaseStudyAsync(int caseStudyId, UpdateCaseStudyDto updateCaseStudyDto);
        Task UpdateReportAsync(int caseStudyId, ReportDTO reportDto);
        Task UpdateMedicalCdhaAsync(int caseStudyId, MedicalCdhaDTO medicalCdhaDto);
        Task UpdatePrescriptionAsync(int caseStudyId, PrescriptionDto prescriptionDto);
    }
}
