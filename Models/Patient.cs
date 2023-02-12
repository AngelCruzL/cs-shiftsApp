using System.ComponentModel.DataAnnotations;

namespace shifts.Models;

public class Patient
{
  [Key] public int Id { get; set; }
  public string Name { get; set; }
  public string LastName { get; set; }
  public string Address { get; set; }
  public string PhoneNumber { get; set; }
  public string Email { get; set; }
}