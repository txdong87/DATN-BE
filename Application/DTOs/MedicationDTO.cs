using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{

    public class MedicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Route { get; set; }
        public string Usage { get; set; }
        public bool IsFunctionalFoods { get; set; }
    }


}
