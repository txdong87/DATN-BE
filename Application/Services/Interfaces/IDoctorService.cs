using System.Threading.Tasks;
using Application.DTOs;
namespace Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<GetDoctorResponse> GetDoctorByIdAsync(int doctorId);
    }
}

