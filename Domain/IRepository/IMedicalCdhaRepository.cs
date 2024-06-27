using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IMedicalCdhaRepository
    {
        Task<IEnumerable<MedicalCdha>> GetAllAsync();
        Task<MedicalCdha> GetMedicalCdhaByIdAsync(int id);
        Task AddMedicalCdhaAsync(MedicalCdha medicalCdha);
        Task UpdateAsync(MedicalCdha entity);
        Task DeleteAsync(int id);
    }
}
