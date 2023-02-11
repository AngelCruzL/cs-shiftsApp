using Microsoft.EntityFrameworkCore;

namespace shifts.Models;

public class ShiftsContext : DbContext

{
  public ShiftsContext(DbContextOptions<ShiftsContext> options) : base(options)
  {
  }

  public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
}