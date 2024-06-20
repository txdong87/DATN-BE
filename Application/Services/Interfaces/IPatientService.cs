using Application.Common.Models;
using Application.DTOs;
using Application.DTOs.PatientDTO;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int patientId);
        Task<Response<PatientDto>> AddPatientAsync(PatientDto patientDto);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int patientId);
        Task<IEnumerable<PatientSearchDTO>> SearchPatientsAsync(string name, int take, int skip);
    }
}
