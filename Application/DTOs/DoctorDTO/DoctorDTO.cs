using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DoctorCreateDto
    {   
        public int DoctorId {  get; set; }
        public int UserId { get; set; }
        public string DoctorRole { get; set; }
        public string DoctorName { get; set; }
    }

}
