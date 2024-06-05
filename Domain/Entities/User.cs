using System;
using System.Collections.Generic;

namespace Domain.Entities;

    public class User
    {
        public User()
        {
            Doctors = new HashSet<Doctor>();
            Nurses = new HashSet<Nurse>();
        }
    public int Userld { get; set; }
    public string? user { get; set; }
    public string? Fullname { get; set; }
    public string? Password { get; set; }
    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
    public virtual ICollection<Doctor> Doctors { get; set; }
    public virtual ICollection<Nurse> Nurses { get; set; }
}
