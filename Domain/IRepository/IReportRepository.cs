using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IReportRepository
    {
        Task<Report> GetByIdAsync(int id);
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report> AddAsync(Report report);
        Task<Report> UpdateAsync(Report report);
        Task<bool> DeleteAsync(int id);
    }
}
