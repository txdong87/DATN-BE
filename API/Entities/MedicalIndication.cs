using System;
using System.Collections.Generic;

namespace API.Entities
{
    public partial class MedicalIndication
    {
        public int Id { get; set; }
        public int? Patientld { get; set; }

        public virtual Patient? PatientldNavigation { get; set; }
    }
}
