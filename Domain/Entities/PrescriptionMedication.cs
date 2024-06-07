using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PrescriptionMedication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        [Required]
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        [StringLength(200)]
        public string Dosages { get; set; } // Hướng dẫn sử dụng
    }
}
