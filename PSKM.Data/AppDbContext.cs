using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSKM.Common.Enums;
using PSKM.Common.Models.Appointment;
using PSKM.Common.Models.Doctor;
using PSKM.Common.Models.Patient;
using PSKM.Common.Models.Specialist;

namespace PSKM.Data;

public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<SpecialistModel> Specialists { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

                //for patient table in DB
                modelBuilder.Entity<PatientModel>(builder =>
                {
                        builder.ToTable("Patient");
                        builder.HasKey(x => x.PatientId);
                        builder.Property(x => x.PatientName).IsRequired();
                        builder.Property(x => x.DOB).IsRequired();
                        builder.Property(x => x.Gender).IsRequired();
                        builder.Property(x => x.Address).HasMaxLength(128);
                        builder.Property(x => x.Phone).HasMaxLength(25);
                });

                //for specialist table for doctor's specialist in DB
                modelBuilder.Entity<SpecialistModel>(builder =>
                {
                        builder.ToTable("Specialist");
                        builder.HasKey(x => x.SpecialistId);
                        builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
                        builder.Property(x => x.Description).IsRequired();
                });

                //for doctor table in DB
                modelBuilder.Entity<DoctorModel>(builder => 
                {
                        builder.ToTable("Doctor");
                        builder.HasKey(x => x.DoctorId);
                        builder.Property(x => x.DoctorName).IsRequired();
                        builder.Property(x => x.Email).IsRequired();
                        builder.Property(x => x.Phone).IsRequired().HasMaxLength(20);
                        //add specialistid as FK
                        builder.HasOne(d => d.Specialist)
                        .WithMany()
                        .HasForeignKey(x => x.SpecialistId)
                        .OnDelete(DeleteBehavior.SetNull);
                });

                //for appointment table in DB
                modelBuilder.Entity<AppointmentModel>(builder =>
                {
                        builder.ToTable("Appointment");
                        builder.HasKey(x =>x.AppointmentId);
                        builder.Property(x => x.AppointmentDate).IsRequired();

                        // convert enum type into sting for appointment status
                        var statusString = new EnumToStringConverter<EnumAppointmentStatus>();
                        builder.Property(x => x.status)
                        .HasConversion(statusString)
                        .HasDefaultValue(EnumAppointmentStatus.Pending);

                        builder.HasOne<PatientModel>().WithMany()
                        .HasForeignKey(x => x.PatientId)
                        .OnDelete(DeleteBehavior.Restrict).IsRequired(); // prevent delection of doctor if he/she has appointment; delete appointment first.

                        builder.HasOne<DoctorModel>().WithMany()
                        .HasForeignKey(x =>x.DoctorId)
                        .OnDelete(DeleteBehavior.Restrict).IsRequired();
                });
        }
}
