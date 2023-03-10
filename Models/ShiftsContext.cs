using Microsoft.EntityFrameworkCore;

namespace shifts.Models;

public class ShiftsContext : DbContext

{
  public ShiftsContext(DbContextOptions<ShiftsContext> options) : base(options)
  {
  }

  public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
  public DbSet<Patient> Patients { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<MedicalSpeciality>(s =>
      {
        s.ToTable("MedicalSpecialities");
        s.HasKey(s => s.Id);
        s.Property(s => s.Id).ValueGeneratedOnAdd();
        s.Property(s => s.Description).IsRequired().HasMaxLength(200).IsUnicode(false);
      }
    );
  }
}