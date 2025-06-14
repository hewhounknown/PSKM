using Microsoft.EntityFrameworkCore;
using PSKM.Domain.Models.Patient;

namespace PSKM.Data;

public class AppDbContext : DbContext
{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PatientModel> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

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
        }
}
