using Domain.Entities;
using Domain.IRepository;
using Infracstructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Nurse> GetNurseByIdAsync(int nurseId)
        {
            return await _context.Nurses
                                 .Include(d => d.UserldNavigation)
                                 .FirstOrDefaultAsync(d => d.Nurseld == nurseId);
        }
    }
}
