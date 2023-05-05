using Microsoft.EntityFrameworkCore;

namespace shifts.Models;

public class ShiftsContext : DbContext

{
  public ShiftsContext(DbContextOptions<ShiftsContext> options)
    : base(options)
  {
  }

  public DbSet<MedicalSpeciality> MedicalSpecialities { get; set; }
  public DbSet<Patient> Patients { get; set; }
  public DbSet<Medic> Medic { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<MedicalSpeciality>(entity =>
      {
        entity.ToTable("MedicalSpecialities");

        entity.HasKey(s => s.Id);

        entity.Property(s => s.Id)
          .ValueGeneratedOnAdd();

        entity.Property(s => s.Description)
          .IsRequired()
          .HasMaxLength(200)
          .IsUnicode(false);
      }
    );

    modelBuilder.Entity<Patient>(entity =>
    {
      entity.ToTable("Patients");

      entity.HasKey(e => e.Id);

      entity.Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

      entity.Property(p => p.LastName)
        .IsRequired().HasMaxLength(50)
        .IsUnicode(false);

      entity.Property(p => p.Address)
        .IsRequired()
        .HasMaxLength(250)
        .IsUnicode(false);

      entity.Property(p => p.PhoneNumber)
        .IsRequired()
        .HasMaxLength(20)
        .IsUnicode(false);

      entity.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(100)
        .IsUnicode(false);
    });
  }
}