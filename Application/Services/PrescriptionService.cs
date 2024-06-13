using Application.DTOs;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<IEnumerable<PrescriptionDto>> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionRepository.GetAllPrescriptions();

            if (prescriptions == null)
            {
                throw new Exception("Prescriptions list is null");
            }

            return prescriptions.Select(p => new PrescriptionDto
            {
                Id = p.Id,
                PatientId = p.PatientId,
                CasestudyId = p.CasestudyId,
                Date = p.Date,
                PrescriptionMedications = p.PrescriptionMedications?.Select(pm => new PrescriptionMedicationDto
                {
                    MedicationId = pm.MedicationId,
                    Dosages = pm.Dosages
                }).ToList()
            }).ToList();
        }


        public async Task<PrescriptionDto> GetPrescriptionById(int id)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionById(id);
            if (prescription == null) return null;

            return new PrescriptionDto
            {
                Id = prescription.Id,
                PatientId = prescription.PatientId,
                CasestudyId = prescription.CasestudyId,
                Date = prescription.Date,
                PrescriptionMedications = prescription.PrescriptionMedications.Select(pm => new PrescriptionMedicationDto
                {
                    MedicationId = pm.MedicationId,
                    Dosages = pm.Dosages
                }).ToList()
            };
        }

        public async Task AddPrescription(PrescriptionDto prescriptionDto)
        {
            var prescription = new Prescription
            {
                PatientId = prescriptionDto.PatientId,
                CasestudyId = prescriptionDto.CasestudyId,
                Date = prescriptionDto.Date,
                PrescriptionMedications = prescriptionDto.PrescriptionMedications.Select(pm => new PrescriptionMedication
                {
                    MedicationId = pm.MedicationId,
                    Dosages = pm.Dosages
                }).ToList()
            };
            await _prescriptionRepository.AddPrescription(prescription);
        }

        public async Task UpdatePrescription(PrescriptionDto prescriptionDto)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionById(prescriptionDto.Id);
            if (prescription == null) throw new Exception("Prescription not found");

            prescription.PatientId = prescriptionDto.PatientId;
            prescription.CasestudyId = prescriptionDto.CasestudyId;
            prescription.Date = prescriptionDto.Date;
            prescription.PrescriptionMedications = prescriptionDto.PrescriptionMedications.Select(pm => new PrescriptionMedication
            {
                MedicationId = pm.MedicationId,
                Dosages = pm.Dosages
            }).ToList();

            await _prescriptionRepository.UpdatePrescription(prescription);
        }

        public async Task DeletePrescription(int id)
        {
            await _prescriptionRepository.DeletePrescription(id);
        }
    }
}
