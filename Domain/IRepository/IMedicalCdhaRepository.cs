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
        Task<MedicalCdha> GetMedicalCdhaByIdAsync(int id);
        Task AddMedicalCdhaAsync(MedicalCdha medicalCdha);
    }
}
