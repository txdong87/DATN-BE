﻿using Application.DTOs;
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
            //IReportRepository reportRepository,
            IPrescriptionRepository prescriptionRepository,
            IMedicationRepository medicationRepository)
        {
            _caseStudyRepository = caseStudyRepository;
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
                ReportCount = caseStudy.ReportCount,
                Conclusion = caseStudy.Conclusion,
                Diagnostic = caseStudy.Diagnostic,
                Reason = caseStudy.Reason,
                Status = caseStudy.Status,
                CreateDate = caseStudy.CreateDate,
                DoctorId = caseStudy.DoctorId,
                Patient = new PatientDTO
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
                MedicationCDHA = caseStudy.MedicalCdhas.Select(m => new MedicalCdhaDTO
                {
                    CdhaName = m.CdhaName,
                    KtvIdNavigation = m.KtvIdNavigation,
                    result=m.result,
                    ImageLink=m.ImageLink,
                }).ToList(),
                //Prescriptions = caseStudy.Prescriptions.Select(p => new PrescriptionDto
                //{
                //    Id = p.PrescriptionId,
                //    CasestudyId = p.CaseStudyId,
                //    Date = p.Date
                //}).ToList()
            };
        }
        public async Task<IEnumerable<GetCaseStudyDto>> GetAllCaseStudiesAsync()
        {
            var caseStudies = await _caseStudyRepository.GetAllCaseStudiesAsync();
            var caseStudyDtos = new List<GetCaseStudyDto>();

            foreach (var caseStudy in caseStudies)
            {
                var patient = await _patientRepository.GetPatientByIdAsync(caseStudy.patientId);
                var patientDto = new PatientDTO
                {
                    // Map properties
                };

                //var report = await _reportRepository.GetByCaseStudyIdAsync(caseStudy.CaseStudyId);
                //var reportDto = new ReportDto
                //{
                //};

         

                var prescriptions = await _prescriptionRepository.GetPrescriptionById(caseStudy.CaseStudyId);
                //var prescriptionsDto = prescriptions.Select(p => new PrescriptionDto
                //{
                //    // Map properties
                //}).ToList();

                caseStudyDtos.Add(new GetCaseStudyDto
                {
                    CaseStudyId = caseStudy.CaseStudyId,
                    PatientId = caseStudy.patientId,
                    ReportCount = caseStudy.ReportCount,
                    Conclusion = caseStudy.Conclusion,
                    Diagnostic = caseStudy.Diagnostic,
                    Reason = caseStudy.Reason,
                    Status = caseStudy.Status,
                    CreateDate = caseStudy.CreateDate,
                    DoctorId = caseStudy.DoctorId,
                    Patient = patientDto,
                    //Prescriptions = prescriptionsDto
                });
            }

            return caseStudyDtos;
        }


        public async Task AddCaseStudyAsync(CreateCaseStudyDto createCaseStudyDto,Patient patient)
        {

            var patientId = patient.PatientId;
            
            var caseStudy = new Casestudy
            {
                patientId = patientId,
                ReportCount = 0,
                Conclusion = null,
                Diagnostic = null,
                Reason = null,
                Status = "Pending",
                CreateDate = DateTime.Now,
                DoctorId = null
            };

            await _caseStudyRepository.AddCaseStudyAsync(caseStudy);


            //{
            //    var report = new Report
            //    {
            //        DoctorId = createCaseStudyDto.Report.DoctorId,
            //        PatientId = patientId,
            //        Conclusion = createCaseStudyDto.Report.Conclusion,
            //        Diagnostic = createCaseStudyDto.Report.Diagnostic,
            //        DoctorName = createCaseStudyDto.Report.DoctorName,
            //        Image = createCaseStudyDto.Report.Image,
            //        State = createCaseStudyDto.Report.State
            //    };

            //    await _reportRepository.AddAsync(report);
            //    await _reportRepository.SaveChangesAsync();
            //}

            if (createCaseStudyDto.Prescriptions != null)
            {
                //foreach (var prescriptionDto in createCaseStudyDto.Prescriptions)
                //{
                //    prescriptionDto. = patientId; // Update with new patient ID
                //    await _prescriptionService.AddPrescription(prescriptionDto);
                //}
            }
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
