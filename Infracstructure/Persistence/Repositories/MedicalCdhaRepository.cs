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
    public class MedicalCdhaRepository : IMedicalCdhaRepository
    {
        private readonly datnContext _context;
        public async Task<IEnumerable<MedicalCdha>> GetAllAsync()
        {
            return await _context.MedicalCdhas.ToListAsync();
        }
        public MedicalCdhaRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<MedicalCdha> GetMedicalCdhaByIdAsync(int id)
        {
            return await _context.MedicalCdhas.FindAsync(id);
        }

        public async Task AddMedicalCdhaAsync(MedicalCdha medicalCdha)
        {
            await _context.MedicalCdhas.AddAsync(medicalCdha);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(MedicalCdha entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.MedicalCdhas.FindAsync(id);
            if (entity != null)
            {
                _context.MedicalCdhas.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
