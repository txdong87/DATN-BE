using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface INurseRepository
    {
        Task<Nurse> GetNurseByIdAsync(int nurseId);
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Task CreateNurseAsync(Nurse nurse);
        Task UpdateNurseAsync(Nurse nurse);
        Task DeleteNurseAsync(int id);
    }
}
