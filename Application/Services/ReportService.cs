using Application.Services.Interfaces;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            return await _reportRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await _reportRepository.GetAllAsync();
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            return await _reportRepository.AddAsync(report);
        }

        public async Task<Report> UpdateReportAsync(Report report)
        {
            return await _reportRepository.UpdateAsync(report);
        }

        public async Task<bool> DeleteReportAsync(int id)
        {
            return await _reportRepository.DeleteAsync(id);
        }
    }
}
