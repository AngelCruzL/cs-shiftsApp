namespace shifts.Models;

public class MedicMedicalSpeciality
{
  public int IdMedic { get; set; }
  public int IdMedicalSpeciality { get; set; }
  public Medic Medic { get; set; }
  public MedicalSpeciality MedicalSpeciality { get; set; }
}