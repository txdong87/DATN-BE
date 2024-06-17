using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllPrescriptions();
        Task<Prescription> GetPrescriptionById(int id);
        Task AddPrescription(Prescription prescription);
        Task UpdatePrescription(Prescription prescription);
        Task DeletePrescription(int id);
    }
}
