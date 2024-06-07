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
    public class NurseService : INurseService
    {
        private readonly INurseRepository _nurseRepository;
        private readonly IUserRepository _userRepository;

        public NurseService(INurseRepository nurseRepository, IUserRepository userRepository)
        {
            _nurseRepository = nurseRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _nurseRepository.GetAllNursesAsync();
        }

        public async Task<Nurse> GetNurseByIdAsync(int NurseId)
        {
            var Nurse = await _nurseRepository.GetNurseByIdAsync(NurseId);
            if (Nurse != null)
            {
                //Nurse = await _userRepository.GetUserByUsernameAsync(Nurse.UserId);
            }
            return Nurse;
        }

        public async Task AddNurseAsync(Nurse Nurse)
        {
            await _nurseRepository.CreateNurseAsync(Nurse);
        }

        public async Task UpdateNurseAsync(Nurse Nurse)
        {
            await _nurseRepository.UpdateNurseAsync(Nurse);
        }

        public async Task DeleteNurseAsync(int NurseId)
        {
            await _nurseRepository.DeleteNurseAsync(NurseId);
        }
    }
}
