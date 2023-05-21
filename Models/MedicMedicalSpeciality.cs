using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class MedicMedicalSpeciality
{
  public int IdMedic { get; set; }
  public int IdMedicalSpeciality { get; set; }
  public Medic Medic { get; set; }

  [Display(Name = "Especialidades Médicas")]
  public MedicalSpeciality MedicalSpeciality { get; set; }
}