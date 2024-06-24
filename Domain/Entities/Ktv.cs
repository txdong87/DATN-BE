using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class KTV
    {
        public KTV()
        {
            MedicalCdhas = new HashSet<MedicalCdhaCaseStudy>();
        }

        public int KtvId { get; set; }
        public int UserId { get; set; }
        public string? Password { get; set; }
        public string? KtvName { get; set; }
        public int? RoleIndication { get; set; }

        public virtual User? UserldNavigation { get; set; }
        public virtual ICollection<MedicalCdhaCaseStudy> MedicalCdhas { get; set; }
    }
}
