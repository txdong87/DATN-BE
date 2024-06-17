using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMedicationService
    {
        Task<IEnumerable<MedicationDto>> GetAllMedications();
        Task<MedicationDto> GetMedicationById(int id);
        Task AddMedication(MedicationDto medicationDto);
        Task UpdateMedication(MedicationDto medicationDto);
        Task DeleteMedication(int id);
    }
}
