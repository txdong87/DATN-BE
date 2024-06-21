using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    // IReportService.cs
    public interface IReportService
    {
        Task<Report> GetReportByIdAsync(int id);
        Task<IEnumerable<Report>> GetAllReportsAsync();
        Task<Report> CreateReportAsync(Report report);
        Task<Report> UpdateReportAsync(Report report);
        Task<bool> DeleteReportAsync(int id);
    }

}
