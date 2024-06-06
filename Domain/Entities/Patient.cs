using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Casestudies = new HashSet<Casestudy>();
            Reports = new HashSet<Report>();
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Address { get; set; }
        public int? Sex { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        public DateTime? createdAt { get; set; }
        public string? patientCode {  get; set; }

        public virtual ICollection<Casestudy> Casestudies { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
