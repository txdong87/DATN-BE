using Application.DTOs.CaseStudy;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CaseStudyService :ICaseStudyService
    {
        private readonly ICaseStudyRepository _caseStudyRepository;

        public CaseStudyService(ICaseStudyRepository caseStudyRepository)
        {
            _caseStudyRepository = caseStudyRepository;
        }

        public async Task<GetCaseStudyDto> GetCaseStudyByIdAsync(int caseStudyId)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);
            return new GetCaseStudyDto
            {
                CaseStudyId = caseStudy.CaseStudyld,
                PatientId = caseStudy.Patientld,
                PatientName = caseStudy.PatientName,
                Report = caseStudy.Report,
                ReportCount = caseStudy.ReportCount,
                Conclusion = caseStudy.Conclusion,
                Diagnostic = caseStudy.Diagnostic,
                Reason = caseStudy.Reason,
                Status = caseStudy.Status,
                CreateDate = caseStudy.CreateDate,
                DoctorId = caseStudy.DoctorId,
                DoctorName = caseStudy.DoctorName,
                //MedicalCdhas = caseStudy.MedicalCdhas.Select(mc => new GetMedicalCdhaDto
                //{
                //    Name = mc.Name,
                //    Result = mc.Result
                //}).ToList(),
                //MedicalIndications = caseStudy.MedicalIndications.Select(mi => new GetMedicalIndicationDto
                //{
                //    Name = mi.Name,
                //    Result = mi.Result
                //}).ToList(),
                //MedicalTests = caseStudy.MedicalTests.Select(mt => new GetMedicalTestDto
                //{
                //    Name = mt.Name,
                //    Result = mt.Result
                //}).ToList()
            };
        }

        public async Task<IEnumerable<GetCaseStudyDto>> GetAllCaseStudiesAsync()
        {
            var caseStudies = await _caseStudyRepository.GetAllCaseStudiesAsync();
            var caseStudyDtos = new List<GetCaseStudyDto>();

            foreach (var caseStudy in caseStudies)
            {
                caseStudyDtos.Add(new GetCaseStudyDto
                {
                    CaseStudyId = caseStudy.CaseStudyld,
                    PatientId = caseStudy.Patientld,
                    PatientName = caseStudy.PatientName,
                    Report = caseStudy.Report,
                    ReportCount = caseStudy.ReportCount,
                    Conclusion = caseStudy.Conclusion,
                    Diagnostic = caseStudy.Diagnostic,
                    Reason = caseStudy.Reason,
                    Status = caseStudy.Status,
                    CreateDate = caseStudy.CreateDate,
                    DoctorId = caseStudy.DoctorId,
                    DoctorName = caseStudy.DoctorName,
                    //MedicalCdhas = caseStudy.MedicalCdhas.Select(mc => new GetMedicalCdhaDto
                    //{
                    //    Name = mc.Name,
                    //    Result = mc.Result
                    //}).ToList(),
                    //MedicalIndications = caseStudy.MedicalIndications.Select(mi => new GetMedicalIndicationDto
                    //{
                    //    Name = mi.Name,
                    //    Result = mi.Result
                    //}).ToList(),
                    //MedicalTests = caseStudy.MedicalTests.Select(mt => new GetMedicalTestDto
                    //{
                    //    Name = mt.Name,
                    //    Result = mt.Result
                    //}).ToList()
                });
            }

            return caseStudyDtos;
        }

        public async Task AddCaseStudyAsync(CreateCaseStudyDto createCaseStudyDto)
        {
            if (createCaseStudyDto.PatientId == null || createCaseStudyDto.Reason==null || createCaseStudyDto.DoctorId == null || string.IsNullOrEmpty(createCaseStudyDto.PatientName) || string.IsNullOrEmpty(createCaseStudyDto.DoctorName))
            {
                throw new ArgumentException("PatientId, DoctorId, PatientName and DoctorName must be provided.");
            }

            var caseStudy = new Casestudy
            {
                Patientld = createCaseStudyDto.PatientId,
                PatientName = createCaseStudyDto.PatientName,
                Report = createCaseStudyDto.Report,
                ReportCount = createCaseStudyDto.ReportCount,
                Conclusion = createCaseStudyDto.Conclusion,
                Diagnostic = createCaseStudyDto.Diagnostic,
                Reason = createCaseStudyDto.Reason,
                Status = createCaseStudyDto.Status,
                CreateDate = createCaseStudyDto.CreateDate,
                DoctorId = createCaseStudyDto.DoctorId,
                DoctorName = createCaseStudyDto.DoctorName,
                //MedicalCdhas = createCaseStudyDto.MedicalCdhas.Select(mc => new MedicalCdha
                //{
                //    Name = mc.Name,
                //    Result = mc.Result
                //}).ToList(),
                //MedicalIndications = createCaseStudyDto.MedicalIndications.Select(mi => new MedicalIndication
                //{
                //    Name = mi.Name,
                //    Result = mi.Result
                //}).ToList(),
                //MedicalTests = createCaseStudyDto.MedicalTests.Select(mt => new MedicalTest
                //{
                //    Name = mt.Name,
                //    Result = mt.Result
                //}).ToList()
            };

            await _caseStudyRepository.AddCaseStudyAsync(caseStudy);
        }

        public async Task UpdateCaseStudyAsync(int caseStudyId, UpdateCaseStudyDto updateCaseStudyDto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);

            if (caseStudy != null)
            {
                caseStudy.Report = updateCaseStudyDto.Report;
                caseStudy.ReportCount = updateCaseStudyDto.ReportCount;
                caseStudy.Conclusion = updateCaseStudyDto.Conclusion;
                caseStudy.Diagnostic = updateCaseStudyDto.Diagnostic;
                caseStudy.Reason = updateCaseStudyDto.Reason;
                caseStudy.Status = updateCaseStudyDto.Status;
                caseStudy.CreateDate = updateCaseStudyDto.CreateDate;

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }
    }
}
