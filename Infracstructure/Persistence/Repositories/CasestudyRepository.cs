﻿using Domain.Entities;
using Domain.Interfaces;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class CaseStudyRepository : ICaseStudyRepository
    {
        private readonly datnContext _context;

        public CaseStudyRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<Casestudy> GetCaseStudyByIdAsync(int caseStudyId)
        {
            return await _context.Casestudies
              .Include(cs => cs.PatientIdNavigation)
              .Include(cs => cs.DoctorIdNavigation)
              .Include(cs => cs.MedicalCdhas)
                  .ThenInclude(mccs => mccs.MedicalCdhaIdNavigation)
              .Include(cs => cs.Prescriptions)
                  .ThenInclude(p => p.PrescriptionMedications)
                      .ThenInclude(pm => pm.Medication)
              .Include(cs => cs.Report)
              .FirstOrDefaultAsync(cs => cs.CaseStudyId == caseStudyId);
        }

        public async Task<IEnumerable<Casestudy>> GetAllCaseStudiesAsync()
        {
            return await _context.Casestudies
                                 .Include(cs => cs.PatientIdNavigation)
                                 .Include(cs => cs.DoctorIdNavigation)
                                 .Include(cs => cs.MedicalCdhas)
                                    .ThenInclude(mccs => mccs.MedicalCdhaIdNavigation)
                                 .Include(cs => cs.Prescriptions)
                                 .Include(cs => cs.Report)
                                 .ToListAsync();
        }

        public async Task AddCaseStudyAsync(Casestudy caseStudy)
        {
            await _context.Casestudies.AddAsync(caseStudy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCaseStudyAsync(Casestudy caseStudy)
        {
            _context.Casestudies.Update(caseStudy);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
