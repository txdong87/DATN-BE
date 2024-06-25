using Application.DTOs;
using Application.DTOs.CaseStudy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMedicalCdhaCaseStudyService
    {
        Task<IEnumerable<MedicalCdhaCaseStudyDto>> GetAllAsync();
        Task<MedicalCdhaCaseStudyDto> GetByIdAsync(int id);
        Task AddAsync(MedicalCdhaCaseStudyDto dto);
        Task UpdateAsync(MedicalCdhaCaseStudyDto dto);
        Task DeleteAsync(int id);
        Task AddMedicalCdhasToCaseStudyAsync(int caseStudyId, List<GetMedicalCdhaDto> medicalCdhaDtos);
        Task UpdateMedicalCdhaCaseStudyAsync(MedicalCdhaCaseStudyDto dto);
    }
}
