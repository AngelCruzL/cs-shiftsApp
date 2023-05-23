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
  public DbSet<MedicMedicalSpeciality> MedicMedicalSpeciality { get; set; }
  public DbSet<MedicalShift> MedicalShift { get; set; }


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
    });

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

    modelBuilder.Entity<Medic>(entity =>
    {
      entity.ToTable("Medic");

      entity.HasKey(medic => medic.Id);

      entity.Property(medic => medic.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

      entity.Property(medic => medic.LastName)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

      entity.Property(medic => medic.Address)
        .IsRequired()
        .HasMaxLength(250)
        .IsUnicode(false);

      entity.Property(medic => medic.PhoneNumber)
        .IsRequired()
        .HasMaxLength(20)
        .IsUnicode(false);

      entity.Property(medic => medic.Email)
        .IsRequired()
        .HasMaxLength(100)
        .IsUnicode(false);

      entity.Property(medic => medic.ScheduleFrom)
        .IsRequired()
        .IsUnicode(false);

      entity.Property(medic => medic.ScheduleUntil)
        .IsRequired()
        .IsUnicode(false);
    });

    modelBuilder.Entity<MedicMedicalSpeciality>(entity =>
    {
      entity.ToTable("MedicMedicalSpeciality");

      entity.HasKey(mms => new { mms.IdMedic, mms.IdMedicalSpeciality });

      entity.HasOne(mms => mms.Medic)
        .WithMany(m => m.MedicMedicalSpecialities)
        .HasForeignKey(mms => mms.IdMedic);

      entity.HasOne(mms => mms.MedicalSpeciality)
        .WithMany(ms => ms.MedicMedicalSpecialities)
        .HasForeignKey(mms => mms.IdMedicalSpeciality);
    });

    modelBuilder.Entity<MedicalShift>(entity =>
    {
      entity.ToTable("MedicalShift");

      entity.HasKey(ms => ms.Id);

      entity.Property(ms => ms.IdPatient)
        .IsRequired()
        .IsUnicode(false);

      entity.Property(ms => ms.IdMedic)
        .IsRequired()
        .IsUnicode(false);

      entity.Property(ms => ms.ScheduleFrom)
        .IsRequired()
        .IsUnicode(false);

      entity.Property(ms => ms.ScheduleUntil)
        .IsRequired()
        .IsUnicode(false);
    });

    modelBuilder.Entity<MedicalShift>().HasOne(ms => ms.Patient)
      .WithMany(ms => ms.MedicalShifts)
      .HasForeignKey(ms => ms.IdPatient);

    modelBuilder.Entity<MedicalShift>().HasOne(ms => ms.Medic)
      .WithMany(ms => ms.MedicalShifts)
      .HasForeignKey(ms => ms.IdMedic);
  }
}