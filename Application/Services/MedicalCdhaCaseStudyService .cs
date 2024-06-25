using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MedicalCdhaCaseStudyService : IMedicalCdhaCaseStudyService
    {
        private readonly IMedicalCdhaCaseStudyRepository _medicalCdhaCaseStudyRepository;
        private readonly ICaseStudyRepository _caseStudyRepository;
        private readonly IMedicalCdhaRepository _medicalCdhaRepository;

        public MedicalCdhaCaseStudyService(IMedicalCdhaCaseStudyRepository repository, ICaseStudyRepository caseStudyRepository, IMedicalCdhaRepository medicalCdhaRepository)
        {
            _medicalCdhaCaseStudyRepository = repository;
            _caseStudyRepository = caseStudyRepository;
            _medicalCdhaRepository = medicalCdhaRepository;
        }

        public async Task<IEnumerable<MedicalCdhaCaseStudyDto>> GetAllAsync()
        {
            var entities = await _medicalCdhaCaseStudyRepository.GetAllAsync();
            var dtos = new List<MedicalCdhaCaseStudyDto>();
            foreach (var entity in entities)
            {
                dtos.Add(MapToDto(entity));
            }
            return dtos;
        }

        public async Task<MedicalCdhaCaseStudyDto> GetByIdAsync(int id)
        {
            var entity = await _medicalCdhaCaseStudyRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            return MapToDto(entity);
        }

        public async Task AddAsync(MedicalCdhaCaseStudyDto dto)
        {
            var entity = MapToEntity(dto);
            await _medicalCdhaCaseStudyRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(MedicalCdhaCaseStudyDto dto)
        {
            var entity = MapToEntity(dto);
            await _medicalCdhaCaseStudyRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _medicalCdhaCaseStudyRepository.DeleteAsync(id);
        }

        private MedicalCdhaCaseStudyDto MapToDto(MedicalCdhaCaseStudy entity)
        {
            return new MedicalCdhaCaseStudyDto
            {
                Id = entity.Id,
                DoctorId = entity.DoctorId,
                KtvId = entity.KtvId,
                CaseStudyId = entity.CaseStudyId,
                MedicalCdhaId = entity.MedicalCdhaId,
                ReportId = entity.ReportId,
                Conlusion = entity.Conlusion,
                Description = entity.Description,
                ImageName = entity.ImageName,
                ImageLink = entity.ImageLink
            };
        }

        private MedicalCdhaCaseStudy MapToEntity(MedicalCdhaCaseStudyDto dto)
        {
            return new MedicalCdhaCaseStudy
            {
                Id = dto.Id,
                DoctorId = dto.DoctorId,
                KtvId = dto.KtvId,
                CaseStudyId = dto.CaseStudyId,
                MedicalCdhaId = dto.MedicalCdhaId,
                ReportId = dto.ReportId,
                Conlusion = dto.Conlusion,
                Description = dto.Description,
                ImageName = dto.ImageName,
                ImageLink = dto.ImageLink
            };
        }
        public async Task AddMedicalCdhasToCaseStudyAsync(int caseStudyId, List<GetMedicalCdhaDto> medicalCdhaDtos)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);
            if (caseStudy != null)
            {
                foreach (var dto in medicalCdhaDtos)
                {
                    // Check if MedicalCdha already exists
                    var medicalCdha = await _medicalCdhaRepository.GetMedicalCdhaByIdAsync(dto.id);
                    if (medicalCdha == null)
                    {
                        medicalCdha = new MedicalCdha
                        {
                            Id = dto.id,
                            CdhaName = dto.CdhaName
                            // Add other properties as needed
                        };
                        await _medicalCdhaRepository.AddMedicalCdhaAsync(medicalCdha);
                    }

                    // Create MedicalCdhaCaseStudy
                    var newMedicalCdhaCaseStudy = new MedicalCdhaCaseStudy
                    {
                        MedicalCdhaId = medicalCdha.Id,
                        CaseStudyId = caseStudyId,
                        // Set other properties like Conlusion, Description, etc.
                    };

                    await _medicalCdhaCaseStudyRepository.AddAsync(newMedicalCdhaCaseStudy);
                }

                await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
            }
        }



        public async Task UpdateMedicalCdhaCaseStudyAsync(MedicalCdhaCaseStudyDto dto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(dto.Id);
            if (caseStudy != null)
            {
                var medicalCdhaCaseStudy = caseStudy.MedicalCdhas.FirstOrDefault(m => m.Id == dto.Id);
                if (medicalCdhaCaseStudy != null)
                {
                    medicalCdhaCaseStudy.Conlusion = dto.Conlusion;
                    medicalCdhaCaseStudy.Description = dto.Description;
                    medicalCdhaCaseStudy.ImageName = dto.ImageName;
                    medicalCdhaCaseStudy.ImageLink = dto.ImageLink;
                    await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
                }
            }
        }
    }
}
