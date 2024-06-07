using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly datnContext _context;

        public NurseRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _context.Nurses.ToListAsync();
        }

        public async Task<Nurse> GetNurseByIdAsync(int nurseId)
        {
            return await _context.Nurses.FirstOrDefaultAsync(d => d.NurseId == nurseId);
        }

        public async Task CreateNurseAsync(Nurse nurse)
        {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNurseAsync(Nurse nurse)
        {
            _context.Nurses.Update(nurse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNurseAsync(int nurseId)
        {
            var nurse = await _context.Nurses.FindAsync(nurseId);
            if (nurse != null)
            {
                _context.Nurses.Remove(nurse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
