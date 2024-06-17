using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface  IPrescriptionService
    {
        Task<IEnumerable<PrescriptionDto>> GetAllPrescriptions();
        Task<PrescriptionDto> GetPrescriptionById(int id);
        Task AddPrescription(PrescriptionDto prescriptionDto);
        Task UpdatePrescription(PrescriptionDto prescriptionDto);
        Task DeletePrescription(int id);

    }
}
