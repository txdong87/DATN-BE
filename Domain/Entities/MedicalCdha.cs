using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MedicalCdha
    {
        public int Id { get; set; }
        public string CdhaName { get; set; }
       
        public DateTime? DateCreate { get; set; }
        public DateTime? TimeEstimate { get; set; }
        public virtual ICollection<MedicalCdhaCaseStudy> MedicalCdhaCaseStudies { get; set; }


    }
}
