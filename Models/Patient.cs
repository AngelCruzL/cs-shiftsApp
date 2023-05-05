using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class Patient
{
  [Key] public int Id { get; set; }

  [Display(Name = "Nombre")] public string Name { get; set; }

  [Display(Name = "Apellido")] public string LastName { get; set; }
  [Display(Name = "Dirección")] public string Address { get; set; }
  [Display(Name = "Número Teléfonico")] public string PhoneNumber { get; set; }
  [Display(Name = "Correo Electrónico")] public string Email { get; set; }
}