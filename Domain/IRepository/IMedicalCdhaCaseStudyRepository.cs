using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IMedicalCdhaCaseStudyRepository
    {
        Task<IEnumerable<MedicalCdhaCaseStudy>> GetAllAsync();
        Task<MedicalCdhaCaseStudy> GetByIdAsync(int id);
        Task AddAsync(MedicalCdhaCaseStudy medicalCdhaCaseStudy);
        Task UpdateAsync(MedicalCdhaCaseStudy medicalCdhaCaseStudy);
        Task DeleteAsync(int id);
        Task<MedicalCdhaCaseStudy> GetByMedicalCdhaIdAndCaseStudyIdAsync(int medicalCdhaId, int caseStudyId);

    }
}
