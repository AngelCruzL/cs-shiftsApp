using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class Medic
{
  [Key] public int Id { get; set; }

  [Required(ErrorMessage = "Debe ingresar al menos un nombre")]
  [Display(Name = "Nombre(s)")]
  public string Name { get; set; }

  [Required(ErrorMessage = "Debe ingresar al menos un apellido")]
  [Display(Name = "Apellidos")]
  public string LastName { get; set; }

  [Required(ErrorMessage = "Debe ingresar una dirección")]
  [Display(Name = "Dirección")]
  public string Address { get; set; }

  [Required(ErrorMessage = "Debe ingresar un número teléfonico")]
  [Display(Name = "Número Teléfonico")]
  public string PhoneNumber { get; set; }

  [Required(ErrorMessage = "Debe ingresar un correo electrónico")]
  [Display(Name = "Correo Electrónico")]
  [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido")]
  public string Email { get; set; }


  [Display(Name = "Hora de Inicio")]
  [DataType(DataType.Time)]
  [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
  public DateTime ScheduleFrom { get; set; }

  [Display(Name = "Hora de Salida")]
  [DataType(DataType.Time)]
  [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
  public DateTime ScheduleUntil { get; set; }

  public List<MedicMedicalSpeciality>? MedicMedicalSpecialities { get; set; }
}