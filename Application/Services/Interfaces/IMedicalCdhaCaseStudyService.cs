using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.DTOs.MedicalCdhaCaseStudyDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMedicalCdhaCaseStudyService
    {
        Task<IEnumerable<GetMedicalCdhaCaseStudyDto>> GetAllAsync();
        Task<GetMedicalCdhaCaseStudyDto> GetByIdAsync(int id);
        Task AddAsync(MedicalCdhaCaseStudyDto dto);
        Task UpdateAsync(MedicalCdhaCaseStudyDto dto);
        Task DeleteAsync(int id);
        Task AddMedicalCdhasToCaseStudyAsync(int caseStudyId, AddMedicalCdhaCaseStudyDto medicalCdhaDtos);
        Task UpdateMedicalCdhaCaseStudyAsync(MedicalCdhaCaseStudyDto dto);
    }
}
