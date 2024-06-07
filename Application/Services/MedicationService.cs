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

        public async Task<IEnumerable<Medication>> GetAllMedicationsAsync()
        {
            return await _medicationRepository.GetAllAsync();
        }

        public async Task<Medication> GetMedicationByIdAsync(int id)
        {
            return await _medicationRepository.GetByIdAsync(id);
        }

        public async Task AddMedicationAsync(Medication medication)
        {
            await _medicationRepository.AddAsync(medication);
        }

        public async Task UpdateMedicationAsync(Medication medication)
        {
            await _medicationRepository.UpdateAsync(medication);
        }

        public async Task DeleteMedicationAsync(int id)
        {
            await _medicationRepository.DeleteAsync(id);
        }
    }
}
