using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.PrescriptionDTO
{
    public class CreatePrescriptionDto
    {
        public string Medication { get; set; }
        public string Dosage { get; set; }
    }
}
