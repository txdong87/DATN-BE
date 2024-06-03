using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;

namespace Application.Services
{
    public class NurseService : INurseService
    {
        private readonly INurseRepository _nurseRepository;

        public NurseService(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<GetNurseResponse> GetNurseByIdAsync(int nurseId)
        {
            var nurse = await _nurseRepository.GetNurseByIdAsync(nurseId);
            return nurse == null ? null : new GetNurseResponse(nurse);
        }
    }
}
