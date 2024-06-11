using Domain.Entities;
using Domain.Interfaces;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Infrastructure.Persistence.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly datnContext _context;

        public MedicationRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medication>> GetAllMedications()
        {
            return await _context.Medication.ToListAsync();
        }

        public async Task<Medication> GetMedicationById(int id)
        {
            return await _context.Medication.FindAsync(id);
        }

        public async Task AddMedication(Medication medication)
        {
            _context.Medication.Add(medication);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMedication(Medication medication)
        {
            _context.Medication.Update(medication);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedication(int id)
        {
            var medication = await _context.Medication.FindAsync(id);
            if (medication != null)
            {
                _context.Medication.Remove(medication);
                await _context.SaveChangesAsync();
            }
        }
    }

}
