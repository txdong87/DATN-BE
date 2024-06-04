using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class MedicalIndication
    {
        public int Id { get; set; }
        public int? CaseStudyId { get; set; }
        public virtual Casestudy? CaseStudyIdNavigation { get; set; }

    }
}
