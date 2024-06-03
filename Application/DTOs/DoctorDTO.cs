using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetDoctorResponse
    {
        public GetDoctorResponse(Domain.Entities.Doctor doctor)
        {
            DoctorId = doctor.Doctorld;
            UserId = doctor.Userld ?? 0;
            Fullname = doctor.UserldNavigation?.Fullname;
        }

        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string Fullname { get; set; }
    }
}
