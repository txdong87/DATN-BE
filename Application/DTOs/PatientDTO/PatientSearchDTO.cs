using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.PatientDTO
{
    public class PatientSearchDTO
    {
        public string Name { get; set; }
        public string PatientCode { get; set; }
        public int Take { get; set; } = 10; // Default value
        public int Skip { get; set; } = 0;  // Default value
    }
}
