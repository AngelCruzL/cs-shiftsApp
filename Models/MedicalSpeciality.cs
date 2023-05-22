using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class MedicalSpeciality
{
  [Key] public int Id { get; set; }

  [StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]
  [Required(ErrorMessage = "Debe ingresar una descripción")]
  [Display(Name = "Descripción", Prompt = "Ingrese una descripción")]
  public string Description { get; set; }

  public List<MedicMedicalSpeciality>? MedicMedicalSpecialities { get; set; }
}