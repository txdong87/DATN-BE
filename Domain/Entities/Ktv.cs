using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Ktv
    {
        public Ktv()
        {
            MedicalCdhas = new HashSet<MedicalCdha>();
            MedicalTests = new HashSet<MedicalTest>();
        }

        public int Ktvld { get; set; }
        public Guid UserId { get; set; }
        public string? Password { get; set; }
        public string? KtvName { get; set; }
        public int? RoleIndication { get; set; }

        public virtual User? UserldNavigation { get; set; }
        public virtual ICollection<MedicalCdha> MedicalCdhas { get; set; }
        public virtual ICollection<MedicalTest> MedicalTests { get; set; }
    }
}
