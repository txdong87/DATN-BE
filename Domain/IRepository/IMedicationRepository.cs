using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAllMedications();
        Task<Medication> GetMedicationById(int id);
        Task AddMedication(Medication medication);
        Task UpdateMedication(Medication medication);
        Task DeleteMedication(int id);
    }
}
 