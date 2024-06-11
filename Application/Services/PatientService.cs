using Application.DTOs;
using Domain.Entities;
using Domain.IRepository;
using Application.Utilities;
using System;
using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _patientRepository.GetPatientByIdAsync(patientId);
        }

        public async Task<Response<PatientDTO>> AddPatientAsync(PatientDTO patientDto)
        {
            if (patientDto == null)
            {
                throw new ArgumentNullException(nameof(patientDto));
            }

            var patient = new Patient
            {
                PatientName = patientDto.PatientName,
                Address = patientDto.Address,
                Sex = patientDto.Sex,
                Dob = patientDto.Dob,
                Phone = patientDto.Phone,
                patientCode = PatientCodeGenerator.GeneratePatientCode(),
                createdAt = DateTime.Now,
            };

            await _patientRepository.AddPatientAsync(patient);
            var response = new Response<PatientDTO>(isSuccess: true, data: patientDto);

            return response;
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdatePatientAsync(patient);
        }

        public async Task DeletePatientAsync(int patientId)
        {
            await _patientRepository.DeletePatientAsync(patientId);
        }
    }
}
