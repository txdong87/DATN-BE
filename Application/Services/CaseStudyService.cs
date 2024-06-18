using Application.DTOs.CaseStudy;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CaseStudyService :ICaseStudyService
    {
        private readonly ICaseStudyRepository _caseStudyRepository;
        private readonly IPatientRepository _patientRepository;
        public CaseStudyService(ICaseStudyRepository caseStudyRepository, IPatientRepository patientRepository)
        {
            _caseStudyRepository = caseStudyRepository;
            _patientRepository = patientRepository;
        }

        public async Task<GetCaseStudyDto> GetCaseStudyByIdAsync(int CaseStudyId)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(CaseStudyId);
            if (caseStudy == null)
            {
                return null;
            }

            var patient = await _patientRepository.GetPatientByIdAsync(caseStudy.patientId);
            if (patient == null)
            {
                return null;
            }
            return new GetCaseStudyDto
            {
                CaseStudyId = caseStudy.CaseStudyId,
                //PatientId = caseStudy.patientId,
                Report = caseStudy.Report,
                ReportCount = caseStudy.ReportCount,
                Conclusion = caseStudy.Conclusion,
                Diagnostic = caseStudy.Diagnostic,
                Reason = caseStudy.Reason,
                Status = caseStudy.Status,
                CreateDate = caseStudy.CreateDate,
                DoctorId = caseStudy.DoctorId,
                
                //MedicalCdhas = caseStudy.MedicalCdhas.Select(mc => new GetMedicalCdhaDto
                //{
                //    Name = mc.Name,
                //    Result = mc.Result
                //}).ToList(),
            };
        }

        public async Task<IEnumerable<GetCaseStudyDto>> GetAllCaseStudiesAsync()
        {
            var caseStudies = await _caseStudyRepository.GetAllCaseStudiesAsync();
            var caseStudyDtos = new List<GetCaseStudyDto>();

            foreach (var caseStudy in caseStudies)
            {
                var patient = await _patientRepository.GetPatientByIdAsync(caseStudy.patientId);
                if (patient != null)
                {
                    caseStudyDtos.Add(new GetCaseStudyDto
                    {
                        CaseStudyId = caseStudy.CaseStudyId,
                        PatientId = caseStudy.patientId,
                        Report = caseStudy.Report,
                        ReportCount = caseStudy.ReportCount,
                        Conclusion = caseStudy.Conclusion,
                        Diagnostic = caseStudy.Diagnostic,
                        Reason = caseStudy.Reason,
                        Status = caseStudy.Status,
                        CreateDate = caseStudy.CreateDate,
                        DoctorId = caseStudy.DoctorId,
                        PatientName = patient.PatientName,
                        // Assuming these properties exist in GetCaseStudyDto
                        Address = patient.Address,
                        Sex = patient.Sex,
                        Dob = patient.Dob,
                        Phone = patient.Phone,
                        PatientCode = patient.patientCode,
                        CreatedAt = patient.createdAt
                    });
                }
            }

            return caseStudyDtos;
        }


        public async Task AddCaseStudyAsync(CreateCaseStudyDto createCaseStudyDto)
        {
            if (createCaseStudyDto.PatientId == null || createCaseStudyDto.Reason==null )
            {
                throw new ArgumentException("PatientId, PatientName and DoctorName must be provided.");
            }

            var caseStudy = new Casestudy
            {
                //patientId = createCaseStudyDto.PatientId,
                //Report = createCaseStudyDto.Report,
                //ReportCount = createCaseStudyDto.ReportCount,
                //Conclusion = createCaseStudyDto.Conclusion,
                Diagnostic = createCaseStudyDto.Diagnostic,
                Reason = createCaseStudyDto.Reason,
                Status = createCaseStudyDto.Status,
                CreateDate = createCaseStudyDto.CreateDate,
                DoctorId = createCaseStudyDto.DoctorId,
                
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
