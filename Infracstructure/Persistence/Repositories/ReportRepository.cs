using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infracstructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Domain.IRepository;
namespace Infrastructure.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly datnContext _context;

        public ReportRepository(datnContext context)
        {
            _context = context;
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _context.Reports.ToListAsync();
        }

        public async Task<Report> AddAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<Report> UpdateAsync(Report report)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return false;
            }

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
