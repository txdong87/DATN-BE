using System.Threading.Tasks;
using Application.DTOs;
using Application.Services.Interfaces;
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

        public async Task<GetDoctorResponse> GetDoctorByIdAsync(int doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
            return doctor == null ? null : new GetDoctorResponse(doctor);
        }
    }
}
