﻿using Application.DTOs;
using Application.DTOs.CaseStudy;
using Application.DTOs.MedicalCdhaCaseStudyDTO;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<GetMedicalCdhaCaseStudyDto>> GetAllAsync()
        {
            var entities = await _medicalCdhaCaseStudyRepository.GetAllAsync();
            var dtos = new List<GetMedicalCdhaCaseStudyDto>();
            foreach (var entity in entities)
            {
                var dto = new GetMedicalCdhaCaseStudyDto
                {
                    Id = entity.Id,
                    KtvId = entity.KtvId,
                    CaseStudyId = entity.CaseStudyId,
                    patientName = entity.CaseStudyIdNavigation?.PatientIdNavigation?.PatientName ?? string.Empty,
                    MedicalCdhaName = entity.MedicalCdhaIdNavigation?.CdhaName ?? string.Empty,
                    DateCreate=entity.MedicalCdhaIdNavigation.DateCreate,
                    ReportId = entity.ReportId,
                    Conlusion = entity.Conclusion,
                    Description = entity.Description,
                    ImageName = entity.ImageName,
                    ImageLink = entity.ImageLink
                };
                dtos.Add(dto);
            }
            return dtos;
        }

        public async Task<GetMedicalCdhaCaseStudyDto> GetByIdAsync(int id)
        {
            var entity = await _medicalCdhaCaseStudyRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }

            var dto = new GetMedicalCdhaCaseStudyDto
            {
                Id = entity.Id,
                KtvId = entity.KtvId,
                CaseStudyId = entity.CaseStudyId,
                patientName = entity.CaseStudyIdNavigation?.PatientIdNavigation?.PatientName ?? string.Empty,
                MedicalCdhaName = entity.MedicalCdhaIdNavigation?.CdhaName ?? string.Empty,
                DateCreate = entity.MedicalCdhaIdNavigation.DateCreate,
                ReportId = entity.ReportId,
                Conlusion = entity.Conclusion,
                Description = entity.Description,
                ImageName = entity.ImageName,
                ImageLink = entity.ImageLink
            };
            return dto;
        }

        public async Task AddAsync(MedicalCdhaCaseStudyDto dto)
        {
            var entity = new MedicalCdhaCaseStudy
            {
                Id = dto.Id,
                KtvId = dto.KtvId,
                CaseStudyId = dto.CaseStudyId,
                MedicalCdhaId = dto.MedicalCdhaId,
                ReportId = dto.ReportId,
                Conclusion = dto.Conlusion,
                Description = dto.Description,
                ImageName = dto.ImageName,
                ImageLink = dto.ImageLink
            };
            await _medicalCdhaCaseStudyRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(MedicalCdhaCaseStudyDto dto)
        {
            var entity = new MedicalCdhaCaseStudy
            {
                Id = dto.Id,
                KtvId = dto.KtvId,
                CaseStudyId = dto.CaseStudyId,
                MedicalCdhaId = dto.MedicalCdhaId,
                ReportId = dto.ReportId,
                Conclusion = dto.Conlusion,
                Description = dto.Description,
                ImageName = dto.ImageName,
                ImageLink = dto.ImageLink
            };
            await _medicalCdhaCaseStudyRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _medicalCdhaCaseStudyRepository.DeleteAsync(id);
        }

        public async Task AddMedicalCdhasToCaseStudyAsync(int caseStudyId, AddMedicalCdhaCaseStudyDto medicalCdhaDtos)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(caseStudyId);
            if (caseStudy == null)
            {
                throw new NotFoundException($"CaseStudy with ID {caseStudyId} not found.");
            }

            var medicalCdha = await _medicalCdhaRepository.GetMedicalCdhaByIdAsync(medicalCdhaDtos.MedicalCdhaId);
            if (medicalCdha == null)
            {
                medicalCdha = new MedicalCdha
                {
                    Id = medicalCdhaDtos.MedicalCdhaId,
                };
                await _medicalCdhaRepository.AddMedicalCdhaAsync(medicalCdha);
            }

            var newMedicalCdhaCaseStudy = new MedicalCdhaCaseStudy
            {
                MedicalCdhaId = medicalCdha.Id,
                KtvId = medicalCdhaDtos.KtvId,
            };

            await _medicalCdhaCaseStudyRepository.AddAsync(newMedicalCdhaCaseStudy);
            await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
        }

        public async Task UpdateMedicalCdhaCaseStudyAsync(MedicalCdhaCaseStudyDto dto)
        {
            var caseStudy = await _caseStudyRepository.GetCaseStudyByIdAsync(dto.Id);
            if (caseStudy != null)
            {
                var medicalCdhaCaseStudy = caseStudy.MedicalCdhas.FirstOrDefault(m => m.Id == dto.Id);
                if (medicalCdhaCaseStudy != null)
                {
                    medicalCdhaCaseStudy.Conclusion = dto.Conlusion;
                    medicalCdhaCaseStudy.Description = dto.Description;
                    medicalCdhaCaseStudy.ImageName = dto.ImageName;
                    medicalCdhaCaseStudy.ImageLink = dto.ImageLink;
                    await _caseStudyRepository.UpdateCaseStudyAsync(caseStudy);
                }
            }
        }
    }
}
