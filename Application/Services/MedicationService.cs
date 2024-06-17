using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public async Task<IEnumerable<MedicationDto>> GetAllMedications()
        {
            var medications = await _medicationRepository.GetAllMedications();
            // Map entities to DTOs (use a mapper library like AutoMapper in real projects)
            return medications.Select(m => new MedicationDto
            {
                Id = m.Id,
                Name = m.Name,
                Unit = m.Unit,
                Route = m.Route,
                Usage = m.Usage,
                IsFunctionalFoods = m.IsFunctionalFoods
            });
        }

        public async Task<MedicationDto> GetMedicationById(int id)
        {
            var medication = await _medicationRepository.GetMedicationById(id);
            // Map entity to DTO
            return new MedicationDto
            {
                Id = medication.Id,
                Name = medication.Name,
                Unit = medication.Unit,
                Route = medication.Route,
                Usage = medication.Usage,
                IsFunctionalFoods = medication.IsFunctionalFoods
            };
        }

        public async Task AddMedication(MedicationDto medicationDto)
        {
            var medication = new Medication
            {
                Name = medicationDto.Name,
                Unit = medicationDto.Unit,
                Route = medicationDto.Route,
                Usage = medicationDto.Usage,
                IsFunctionalFoods = medicationDto.IsFunctionalFoods
            };
            await _medicationRepository.AddMedication(medication);
        }

        public async Task UpdateMedication(MedicationDto medicationDto)
        {
            var medication = await _medicationRepository.GetMedicationById(medicationDto.Id);
            if (medication == null) throw new Exception("Medication not found");

            medication.Name = medicationDto.Name;
            medication.Unit = medicationDto.Unit;
            medication.Route = medicationDto.Route;
            medication.Usage = medicationDto.Usage;
            medication.IsFunctionalFoods = medicationDto.IsFunctionalFoods;

            await _medicationRepository.UpdateMedication(medication);
        }

        public async Task DeleteMedication(int id)
        {
            await _medicationRepository.DeleteMedication(id);
        }
    }
}
