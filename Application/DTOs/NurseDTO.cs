using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GetNurseResponse
    {
        public GetNurseResponse(Domain.Entities.Nurse nurse)
        {
            NurseId = nurse.NurseId;
            UserId = nurse.UserId ;
        }

        public int NurseId { get; set; }
        public int UserId { get; set; }
    }
}
