using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;

namespace Application.Services
{
    public class KTVService : IKTVService
    {
        private readonly IKTVRepository _ktvRepository;

        public KTVService(IKTVRepository ktvRepository)
        {
            _ktvRepository = ktvRepository;
        }

        public async Task<GetKTVResponse> GetKTVByIdAsync(int ktvId)
        {
            var ktv = await _ktvRepository.GetKTVByIdAsync(ktvId);
            return ktv == null ? null : new GetKTVResponse(ktv);
        }
    }
}
