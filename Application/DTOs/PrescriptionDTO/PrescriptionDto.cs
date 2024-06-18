using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? CasestudyId { get; set; }
        public DateTime Date { get; set; }
        public List<PrescriptionMedicationDto> PrescriptionMedications { get; set; }
    }
}
