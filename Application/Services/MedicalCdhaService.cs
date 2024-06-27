using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MedicalCdhaService:IMedicalCdhaService
    {
        private readonly IMedicalCdhaRepository _repository;

        public MedicalCdhaService(IMedicalCdhaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MedicalCdha>> GetAllMedicalCdhasAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MedicalCdha> GetMedicalCdhaByIdAsync(int id)
        {
            return await _repository.GetMedicalCdhaByIdAsync(id);
        }

        public async Task<int> CreateMedicalCdhaAsync(MedicalCdha entity)
        {
            await _repository.AddMedicalCdhaAsync(entity);
            return entity.Id;
        }

        public async Task UpdateMedicalCdhaAsync(MedicalCdha entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteMedicalCdhaAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
