using Domain.Entities;
using Domain.IRepository;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly datnContext _context;

        public PrescriptionRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAllPrescriptions()
        {
            return await _context.Prescription
                                 .Include(p => p.PrescriptionMedications)  // Eager load the related PrescriptionMedications
                                 .ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionById(int id)
        {
            return await _context.Prescription
                                 .Include(p => p.PrescriptionMedications)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task AddPrescription(Prescription prescription)
        {
            _context.Prescription.Add(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePrescription(Prescription prescription)
        {
            _context.Prescription.Update(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescription(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescription.Remove(prescription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
