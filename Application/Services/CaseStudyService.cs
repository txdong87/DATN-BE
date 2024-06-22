using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.DTOs;
using Application.DTOs.PrescriptionDTO;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.PatientDTO;

namespace Application.Services
{
    public class CaseStudyService :ICaseStudyService
    {
        private readonly ICaseStudyRepository _caseStudyRepository;
        //private readonly IReportRepository _reportRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IPatientRepository _patientRepository;


        public CaseStudyService(
            ICaseStudyRepository caseStudyRepository,
            IPatientRepository patientRepository,
            //IReportRepository reportRepository,
            IPrescriptionRepository prescriptionRepository,
            IMedicationRepository medicationRepository)
        {
            _caseStudyRepository = caseStudyRepository;
            _patientRepository=patientRepository;
            //_reportRepository = reportRepository;
            _prescriptionRepository = prescriptionRepository;
            _medicationRepository = medicationRepository;
        }

        public async Task<GetCaseStudyDto> GetCaseStudyByIdAsync(int id)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(id);
            if (caseStudy == null)
                return null;

            return new GetCaseStudyDto
            {
                CaseStudyId = caseStudy.CaseStudyId,
                PatientId = caseStudy.patientId,
                Conclusion = caseStudy.Conclusion,
                Diagnostic = caseStudy.Diagnostic,
                Reason = caseStudy.Reason,
                Status = caseStudy.Status,
                CreateDate = caseStudy.CreateDate,
                DoctorId = caseStudy.DoctorId,
                Patient = new PatientDto
                {
                    PatientId = caseStudy.PatientIdNavigation.PatientId,
                    PatientName = caseStudy.PatientIdNavigation.PatientName,
                    Address = caseStudy.PatientIdNavigation.Address,
                    Dob = caseStudy.PatientIdNavigation.Dob,
                    PatientCode = caseStudy.PatientIdNavigation.patientCode,
                    Phone = caseStudy.PatientIdNavigation.Phone,
                    Sex = caseStudy.PatientIdNavigation.Sex,
                    createdAt = caseStudy.PatientIdNavigation.createdAt
                },
                //Report = new ReportDTO
                //{
                //    ReportId = caseStudy.Report.ReportId,
                //    DoctorId = caseStudy.Report.DoctorId,
                //    PatientId = caseStudy.Report.PatientId,
                //    Conclusion = caseStudy.Report.Conclusion,
                //    Diagnostic = caseStudy.Report.Diagnostic,
                //    DoctorName = caseStudy.Report.DoctorName,
                //    Image = caseStudy.Report.Image,
                //    State = caseStudy.Report.State
                //},
                //MedicationCDHA = caseStudy.MedicalCdhas.Select(m => new MedicalCdhaDTO
                //{
                //    CdhaName = m.CdhaName,
                //    KtvIdNavigation = m.KtvIdNavigation,
                //    result=m.result,
                //    ImageLink=m.ImageLink,
                //}).ToList(),

                Prescriptions = caseStudy.Prescriptions.Select(p => new PrescriptionDto
                {
                    Id = p.Id,
                    CasestudyId = p.CasestudyId,
                    Date = p.Date
                }).ToList(),
                 MedicalCdhas = caseStudy.MedicalCdhas.Select(p => new MedicalCdhaDTO
                 {
                     Id = p.Id,
                     CdhaName=p.CdhaName,
                     ImageLink=p.ImageLink,
                     DateCreate=p.DateCreate,
                     ImageName=p.ImageName,
                     result=p.result,
                 }).ToList()
            };
        }
        public async Task<IEnumerable<GetCaseStudyDto>> GetAllCaseStudiesAsync()
        {
            var caseStudies = await _caseStudyRepository.GetAllCaseStudiesAsync();
            var caseStudyDtos = new List<GetCaseStudyDto>();

            foreach (var caseStudy in caseStudies)
            {

                // Map PatientDto
                var patientDto = new PatientDto
                {
                    PatientId = caseStudy.PatientIdNavigation.PatientId,
                    PatientName = caseStudy.PatientIdNavigation.PatientName,
                    Address = caseStudy.PatientIdNavigation.Address,
                    Dob = caseStudy.PatientIdNavigation.Dob,
                    PatientCode = caseStudy.PatientIdNavigation.patientCode,
                    Phone = caseStudy.PatientIdNavigation.Phone,
                    Sex = caseStudy.PatientIdNavigation.Sex,
                    createdAt = caseStudy.PatientIdNavigation.createdAt
                };

                // Map ReportDtos
                var reportDtos = caseStudy.Report.Select(r => new ReportDTO
                {
                    ReportId = r.ReportId,
                    DoctorId = r.DoctorId,
                    PatientId = r.PatientId,
                    Conclusion = r.Conclusion,
                    Diagnostic = r.Diagnostic,
                    Image = r.Image,
                    State = r.State,// Example, adjust as per your needs
                }).ToList();

                // Map PrescriptionDtos
                var prescriptionDtos = caseStudy.Prescriptions.Select(p => new PrescriptionDto
                {
                    Id = p.Id,
                    CasestudyId = p.CasestudyId,
                    Date = p.Date
                }).ToList();

                // Map MedicalCdhaDtos
                var medicalCdhaDtos = caseStudy.MedicalCdhas.Select(m => new MedicalCdhaDTO
                {
                    Id = m.Id,
                    CdhaName = m.CdhaName,
                    ImageLink = m.ImageLink,
                    DateCreate = m.DateCreate, 
                    ImageName = m.ImageName,
                    result = m.result
                }).ToList();

                // Create GetCaseStudyDto and add to list
                var caseStudyDto = new GetCaseStudyDto
                {
                    CaseStudyId = caseStudy.CaseStudyId,
                    PatientId = caseStudy.patientId,
                    Conclusion = caseStudy.Conclusion,
                    Diagnostic = caseStudy.Diagnostic,
                    Reason = caseStudy.Reason,
                    Status = caseStudy.Status,
                    CreateDate = caseStudy.CreateDate,
                    DoctorId = caseStudy.DoctorId,
                    Patient = patientDto,
                    Reports = reportDtos,
                    Prescriptions = prescriptionDtos,
                    MedicalCdhas = medicalCdhaDtos
                };

                caseStudyDtos.Add(caseStudyDto);
            }

            return caseStudyDtos;
        }


        public async Task AddCaseStudyAsync(CreateCaseStudyDto createCaseStudyDto)
        {
            var patientId = createCaseStudyDto.patientId;
            var caseStudy = new Casestudy
            {
                patientId = patientId,
                Conclusion = null,
                Diagnostic = null,
                Reason = null,
                Status = "Pending",
                CreateDate = DateTime.Now,
                DoctorId = null
            };

            await _caseStudyRepository.AddCaseStudyAsync(caseStudy);
        }


        public async Task UpdateCaseStudyAsync(int caseStudyId, UpdateCaseStudyDto updateCaseStudyDto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);

            if (caseStudy != null)
            {
                caseStudy.Reason = updateCaseStudyDto.Reason;
                caseStudy.Status = updateCaseStudyDto.Status;
                caseStudy.CreateDate = updateCaseStudyDto.CreateDate;

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }
        public async Task UpdateReportAsync(int caseStudyId, ReportDTO reportDto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);

            if (caseStudy != null)
            {
                var report = caseStudy.Report.FirstOrDefault(r => r.ReportId == reportDto.ReportId);
                if (report != null)
                {
                    // Update existing report
                    report.Conclusion = reportDto.Conclusion;
                    report.Diagnostic = reportDto.Diagnostic;
                    report.Image = reportDto.Image;
                    report.State = reportDto.State;
                    report.DoctorId = reportDto.DoctorId;
                    report.PatientId = reportDto.PatientId;
                }
                else
                {
                    // Add new report
                    var newReport = new Report
                    {
                        Conclusion = reportDto.Conclusion,
                        Diagnostic = reportDto.Diagnostic,
                        Image = reportDto.Image,
                        State = reportDto.State,
                        DoctorId = reportDto.DoctorId,
                        PatientId = reportDto.PatientId,
                        CaseStudyId = caseStudyId
                    };
                    caseStudy.Report.Add(newReport);
                }

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }
        public async Task UpdateMedicalCdhaAsync(int caseStudyId, MedicalCdhaDTO medicalCdhaDto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);

            if (caseStudy != null)
            {
                var medicalCdha = caseStudy.MedicalCdhas.FirstOrDefault(m => m.Id == medicalCdhaDto.Id);
                if (medicalCdha != null)
                {
                    // Update existing MedicalCdha
                    medicalCdha.CdhaName = medicalCdhaDto.CdhaName;
                    medicalCdha.ImageLink = medicalCdhaDto.ImageLink;
                    medicalCdha.DateCreate = medicalCdhaDto.DateCreate;
                    medicalCdha.ImageName = medicalCdhaDto.ImageName;
                    medicalCdha.result = medicalCdhaDto.result;
                }
                else
                {
                    // Add new MedicalCdha
                    var newMedicalCdha = new MedicalCdha
                    {
                        CdhaName = medicalCdhaDto.CdhaName,
                        ImageLink = medicalCdhaDto.ImageLink,
                        DateCreate = medicalCdhaDto.DateCreate,
                        ImageName = medicalCdhaDto.ImageName,
                        result = medicalCdhaDto.result,
                        CaseStudyId = caseStudyId
                    };
                    caseStudy.MedicalCdhas.Add(newMedicalCdha);
                }

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }
        public async Task UpdatePrescriptionAsync(int caseStudyId, PrescriptionDto prescriptionDto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);

            if (caseStudy != null)
            {
                var prescription = caseStudy.Prescriptions.FirstOrDefault(p => p.Id == prescriptionDto.Id);
                if (prescription != null)
                {
                    // Update existing prescription
                    prescription.Date = prescriptionDto.Date;
                    prescription.CasestudyId = prescriptionDto.CasestudyId;
                }
                else
                {
                    // Add new prescription
                    var newPrescription = new Prescription
                    {
                        Date = prescriptionDto.Date,
                        CasestudyId = caseStudyId
                    };
                    caseStudy.Prescriptions.Add(newPrescription);
                }

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }
    }
}
