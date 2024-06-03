using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entities;
using Infracstructure.Persistance;

namespace Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly datnContext _context;

        public DoctorRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctors
                                 .Include(d => d.UserldNavigation)
                                 .FirstOrDefaultAsync(d => d.Doctorld == doctorId);
        }
    }
}
