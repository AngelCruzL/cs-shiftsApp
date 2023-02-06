using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class MedicalSpeciality
{
  [Key]
  public int Id { get; set; }
  public string Description { get; set; }
}