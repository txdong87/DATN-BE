using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities;
public class Prescription
{
    [Key]
    public int Id { get; set; }
    public int? PatientId { get; set; }
    public int? CasestudyId { get; set; }
    public DateTime Date { get; set; }

    public virtual Patient Patient { get; set; }
    public virtual Casestudy Casestudy { get; set; }
    public virtual ICollection<PrescriptionMedication> PrescriptionMedications { get; set; }
}