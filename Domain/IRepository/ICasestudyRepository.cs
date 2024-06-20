using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICaseStudyRepository
    {
        Task<Casestudy> GetCaseStudyByIdAsync(int caseStudyId);
        Task<IEnumerable<Casestudy>> GetAllCaseStudiesAsync();
        Task AddCaseStudyAsync(Casestudy caseStudy);
        Task UpdateCaseStudyAsync(Casestudy caseStudy);
        Task SaveChangesAsync();
    }
}