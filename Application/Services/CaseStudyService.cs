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

            var reportDtos = caseStudy.Report.Select(r => new ReportDTO
            {
                ReportId = r.ReportId,
                DoctorId = r.DoctorId,
                PatientId = r.PatientId,
                Conclusion = r.Conclusion,
                Diagnostic = r.Diagnostic,
                Image = r.Image,
                State = r.State,
            }).ToList();

            var prescriptionDtos = caseStudy.Prescriptions.Select(p => new PrescriptionDto
            {
                CasestudyId = p.CasestudyId,
                Date = p.Date,
                PrescriptionMedications = p.PrescriptionMedications.Select(pm => new PrescriptionMedicationDto
                {
                    MedicationId = pm.MedicationId,
                    Dosages = pm.Dosages,
                    Medication = new MedicationDto
                    {
                        Name = pm.Medication.Name,
                        Unit = pm.Medication.Unit,
                        Route = pm.Medication.Route,
                        Usage = pm.Medication.Usage,
                        IsFunctionalFoods = pm.Medication.IsFunctionalFoods
                    }
                }).ToList()
            }).ToList();
            var medicalCdhaDtos = caseStudy.MedicalCdhas.Select(m => new MedicalCdhaDTO
            {
                Id = m.Id,
                CdhaName = m.MedicalCdhaIdNavigation.CdhaName,
                ImageLink = m.ImageLink,
                DateCreate = m.MedicalCdhaIdNavigation.DateCreate,
                ImageName = m.ImageName,
                result = m.Conlusion
            }).ToList();

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

            return caseStudyDto;
        }
        public async Task<IEnumerable<GetCaseStudyDto>> GetAllCaseStudiesAsync()
        {
            var caseStudies = await _caseStudyRepository.GetAllCaseStudiesAsync();
            var caseStudyDtos = new List<GetCaseStudyDto>();

            foreach (var caseStudy in caseStudies)
            {

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

                var reportDtos = caseStudy.Report.Select(r => new ReportDTO
                {
                    ReportId = r.ReportId,
                    DoctorId = r.DoctorId,
                    PatientId = r.PatientId,
                    Conclusion = r.Conclusion,
                    Diagnostic = r.Diagnostic,
                    Image = r.Image,
                    State = r.State,
                }).ToList();

                var prescriptionDtos = caseStudy.Prescriptions.Select(p => new PrescriptionDto
                {
                    CasestudyId = p.CasestudyId,
                    Date = p.Date
                }).ToList();

                
                var medicalCdhaDtos = caseStudy.MedicalCdhas.Select(m => new MedicalCdhaDTO
                {
                    Id = m.Id,
                    CdhaName = m.MedicalCdhaIdNavigation.CdhaName,
                    ImageLink = m.ImageLink,
                    DateCreate = m.MedicalCdhaIdNavigation.DateCreate, 
                    ImageName = m.ImageName,
                    result = m.Conlusion
                }).ToList();

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


        public async Task<Casestudy> AddCaseStudyAsync(CreateCaseStudyDto createCaseStudyDto)
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
            return caseStudy;
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
                    report.Conclusion = reportDto.Conclusion;
                    report.Diagnostic = reportDto.Diagnostic;
                    report.Image = reportDto.Image;
                    report.State = reportDto.State;
                    report.DoctorId = reportDto.DoctorId;
                    report.PatientId = reportDto.PatientId;
                }
                else
                {
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
                var medicalCdhaCaseStudy = caseStudy.MedicalCdhas.FirstOrDefault(m => m.MedicalCdhaId == medicalCdhaDto.Id);
                if (medicalCdhaCaseStudy != null)
                {
                    var medicalCdha = medicalCdhaCaseStudy.MedicalCdhaIdNavigation;
                    if (medicalCdha != null)
                    {
                        medicalCdha.CdhaName = medicalCdhaDto.CdhaName;
                        medicalCdha.DateCreate = medicalCdhaDto.DateCreate;
                    }
                    medicalCdhaCaseStudy.ImageLink = medicalCdhaDto.ImageLink;
                    medicalCdhaCaseStudy.ImageName = medicalCdhaDto.ImageName;
                    medicalCdhaCaseStudy.Conlusion = medicalCdhaDto.result;
                }
                else
                {
                    var newMedicalCdha = new MedicalCdha
                    {
                        CdhaName = medicalCdhaDto.CdhaName,
                        DateCreate = medicalCdhaDto.DateCreate
                    };

                    var newMedicalCdhaCaseStudy = new MedicalCdhaCaseStudy
                    {
                        MedicalCdhaIdNavigation = newMedicalCdha,
                        ImageLink = medicalCdhaDto.ImageLink,
                        ImageName = medicalCdhaDto.ImageName,
                        Conlusion = medicalCdhaDto.result,
                        CaseStudyId = caseStudyId
                    };

                    caseStudy.MedicalCdhas.Add(newMedicalCdhaCaseStudy);
                }

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }

        public async Task UpdatePrescriptionAsync(int caseStudyId, PrescriptionDto prescriptionDto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);

            if (caseStudy == null)
            {
                throw new KeyNotFoundException($"CaseStudy with Id {caseStudyId} not found");
            }

            var prescription = caseStudy.Prescriptions.FirstOrDefault(); // Lấy đơn thuốc đầu tiên, có thể cần chỉnh sửa nếu có nhiều đơn thuốc

            if (prescription != null)
            {
                prescription.Date = prescriptionDto.Date;
                prescription.CasestudyId = prescriptionDto.CasestudyId;

                // Xóa các PrescriptionMedication cũ và thêm mới
                prescription.PrescriptionMedications.Clear();

                foreach (var medDto in prescriptionDto.PrescriptionMedications)
                {
                    var medication = await _medicationRepository.GetMedicationById(medDto.MedicationId); // Lấy thông tin thuốc từ database

                    if (medication != null)
                    {
                        var newPrescriptionMedication = new PrescriptionMedication
                        {
                            MedicationId = medication.Id,
                            Dosages = medDto.Dosages
                        };
                        prescription.PrescriptionMedications.Add(newPrescriptionMedication);
                    }
                    else
                    {
                        throw new Exception($"Medication with id {medDto.MedicationId} not found");
                    }
                }
            }
            else
            {
                var newPrescription = new Prescription
                {
                    Date = prescriptionDto.Date,
                    CasestudyId = caseStudyId,
                    PrescriptionMedications = new List<PrescriptionMedication>()
                };

                foreach (var medDto in prescriptionDto.PrescriptionMedications)
                {
                    var medication = await _medicationRepository.GetMedicationById(medDto.MedicationId);

                    if (medication != null)
                    {
                        var newPrescriptionMedication = new PrescriptionMedication
                        {
                            MedicationId = medication.Id,
                            Dosages = medDto.Dosages
                        };
                        newPrescription.PrescriptionMedications.Add(newPrescriptionMedication);
                    }
                    else
                    {
                        throw new Exception($"Medication with id {medDto.MedicationId} not found");
                    }
                }

                caseStudy.Prescriptions.Add(newPrescription);
            }

            await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
        }


    }
}
