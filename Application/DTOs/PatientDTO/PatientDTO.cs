using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PatientDTO
    {
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientCode { get; set; }

        public string? Address { get; set; }
        public int? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
