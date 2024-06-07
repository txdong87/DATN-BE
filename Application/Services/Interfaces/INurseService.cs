using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface INurseService
    {
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Task<Nurse> GetNurseByIdAsync(int NurseId);
        Task AddNurseAsync(Nurse Nurse);
        Task UpdateNurseAsync(Nurse Nurse);
        Task DeleteNurseAsync(int NurseId);
    }
}
