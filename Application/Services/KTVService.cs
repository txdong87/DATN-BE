using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;

namespace Application.Services
{
    public class KTVService : IKTVService
    {
        private readonly IKTVRepository _KTVRepository;
        private readonly IUserRepository _userRepository;

        public KTVService(IKTVRepository KTVRepository, IUserRepository userRepository)
        {
            _KTVRepository = KTVRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<KTV>> GetAllKTVsAsync()
        {
            return await _KTVRepository.GetAllKTVsAsync();
        }

        public async Task<KTV> GetKTVByIdAsync(int KTVId)
        {
            var KTV = await _KTVRepository.GetKTVByIdAsync(KTVId);
            if (KTV != null)
            {
                //KTV = await _userRepository.GetUserByUsernameAsync(KTV.UserId);
            }
            return KTV;
        }

        public async Task AddKTVAsync(KTV KTV)
        {
            await _KTVRepository.CreateKTVAsync(KTV);
        }

        public async Task UpdateKTVAsync(KTV KTV)
        {
            await _KTVRepository.UpdateKTVAsync(KTV);
        }

        public async Task DeleteKTVAsync(int KTVId)
        {
            await _KTVRepository.DeleteKTVAsync(KTVId);
        }
    }
}
