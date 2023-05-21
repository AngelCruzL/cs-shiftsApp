using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class MedicalSpeciality
{
  [Key] public int Id { get; set; }

  [Display(Name = "Descripción")] public string Description { get; set; }
  public List<MedicMedicalSpeciality>? MedicMedicalSpecialities { get; set; }
}