using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorByIdAsync(int doctorId);
    }
}
