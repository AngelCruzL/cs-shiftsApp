using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class MedicalShift
{
  [Key] public int Id { get; set; }

  public int IdPatient { get; set; }
  public int IdMedic { get; set; }

  [Display(Name = "Hora de Inicio")] public DateTime ScheduleFrom { get; set; }

  [Display(Name = "Hora de Salida")] public DateTime ScheduleUntil { get; set; }

  public Patient Patient { get; set; }
  public Medic Medic { get; set; }
}