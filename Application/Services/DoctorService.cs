using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IRepository;
using Infrastructure.Persistence.Repositories;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;

        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
            if (doctor != null)
            {
                //doctor = await _userRepository.GetUserByUsernameAsync(doctor.UserId);
            }
            return doctor;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.CreateDoctorAsync(doctor);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await _doctorRepository.UpdateDoctorAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int doctorId)
        {
            await _doctorRepository.DeleteDoctorAsync(doctorId);
        }
    }
}
