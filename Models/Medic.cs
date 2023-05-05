using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class Medic
{
  [Key] public int Id { get; set; }
  [Display(Name = "Nombre(s)")] public string Name { get; set; }
  [Display(Name = "Apellidos")] public string LastName { get; set; }
  [Display(Name = "Dirección")] public string Address { get; set; }
  [Display(Name = "Número Teléfonico")] public string PhoneNumber { get; set; }
  [Display(Name = "Correo Electrónico")] public string Email { get; set; }
  [Display(Name = "Hora de Inicio")] public DateTime ScheduleFrom { get; set; }
  [Display(Name = "Hora de Salida")] public DateTime ScheduleUntil { get; set; }
}