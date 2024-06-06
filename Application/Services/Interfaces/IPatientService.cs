using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task AddPatientAsync(PatientDTO patientDto);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int patientId);
    }
}
