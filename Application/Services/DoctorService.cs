using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int doctorId)
        {
            return await _doctorRepository.GetDoctorByIdAsync(doctorId);
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
