using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.IRepository;
using Infracstructure.Persistance;

namespace Infrastructure.Repositories
{
    public class MedicalCdhaCaseStudyRepository : IMedicalCdhaCaseStudyRepository
    {
        private readonly datnContext _context;

        public MedicalCdhaCaseStudyRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalCdhaCaseStudy>> GetAllAsync()
        {
            return await _context.MedicalCdhaCaseStudies
                 .Include(x => x.CaseStudyIdNavigation)
                .ThenInclude(cs => cs.PatientIdNavigation)
                .Include(x => x.MedicalCdhaIdNavigation)
                .Include(m => m.CaseStudyIdNavigation.PatientIdNavigation)
                .ToListAsync();
        }

        public async Task<MedicalCdhaCaseStudy> GetByIdAsync(int id)
        {
            return await _context.MedicalCdhaCaseStudies
                .Include(x => x.CaseStudyIdNavigation)
                    .ThenInclude(cs => cs.PatientIdNavigation)
                .Include(x => x.MedicalCdhaIdNavigation)
                .Include(m => m.CaseStudyIdNavigation.PatientIdNavigation)
                 .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(MedicalCdhaCaseStudy medicalCdhaCaseStudy)
        {
            await _context.MedicalCdhaCaseStudies.AddAsync(medicalCdhaCaseStudy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MedicalCdhaCaseStudy medicalCdhaCaseStudy)
        {
            _context.Entry(medicalCdhaCaseStudy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medicalCdhaCaseStudy = await _context.MedicalCdhaCaseStudies.FindAsync(id);
            if (medicalCdhaCaseStudy != null)
            {
                _context.MedicalCdhaCaseStudies.Remove(medicalCdhaCaseStudy);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<MedicalCdhaCaseStudy> GetByMedicalCdhaIdAndCaseStudyIdAsync(int medicalCdhaId, int caseStudyId)
        {
            return await _context.MedicalCdhaCaseStudies
                .FirstOrDefaultAsync(x => x.MedicalCdhaId == medicalCdhaId && x.CaseStudyId == caseStudyId);
        }
    }
}
