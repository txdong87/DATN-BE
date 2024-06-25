using Domain.Entities;
using Domain.IRepository;
using Infracstructure.Persistance;
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
    }
}
