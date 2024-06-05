using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly datnContext _context;

        public DoctorRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.Include(d => d.User).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _context.Doctors.Include(d => d.User).FirstOrDefaultAsync(d => d.Doctorld == doctorId);
        }

        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
