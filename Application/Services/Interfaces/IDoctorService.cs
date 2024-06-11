using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDoctorService
    {
        //Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<IEnumerable<DoctorCreateDto>> GetNameDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
        Task AddDoctorAsync(Doctor doctor);
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int doctorId);
    }
}
