using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Unit { get; set; } // Đơn vị

        [StringLength(100)]
        public string Route { get; set; } // How drug should enter body SNOMED CT Route Codes (Example) - Đường dùng

        [StringLength(100)]
        public string Usage { get; set; } // Đường dùng

        public bool IsFunctionalFoods { get; set; } = false;

        public ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
    }
}
