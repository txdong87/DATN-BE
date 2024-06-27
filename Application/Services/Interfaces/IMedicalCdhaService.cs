using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMedicalCdhaService
    {
        Task<IEnumerable<MedicalCdha>> GetAllMedicalCdhasAsync();
        Task<MedicalCdha> GetMedicalCdhaByIdAsync(int id);
        Task<int> CreateMedicalCdhaAsync(MedicalCdha entity);
        Task UpdateMedicalCdhaAsync(MedicalCdha entity);
        Task DeleteMedicalCdhaAsync(int id);

    }
}
