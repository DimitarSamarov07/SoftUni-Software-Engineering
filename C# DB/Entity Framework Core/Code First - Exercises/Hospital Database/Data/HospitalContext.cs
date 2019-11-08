namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HospitalContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<PatientMedicament> Prescriptions { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Doctors
            modelBuilder
                .Entity<Doctor>()
                .HasKey(k => k.DoctorId);

            modelBuilder
                .Entity<Doctor>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Doctor>()
                .Property(p => p.Specialty)
                .IsUnicode();

            //Patients
            modelBuilder
                .Entity<Patient>()
                .HasKey(k => k.PatientId);

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.FirstName)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.LastName)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Address)
                .IsUnicode();

            modelBuilder
                .Entity<Patient>()
                .Property(p => p.Email)
                .IsUnicode(false);


            //Visitations
            modelBuilder
                .Entity<Visitation>()
                .HasKey(k => k.VisitationId);

            modelBuilder
                .Entity<Visitation>()
                .Property(p => p.Comments)
                .IsUnicode();

            modelBuilder
                .Entity<Visitation>()
                .HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId);

            modelBuilder
                .Entity<Visitation>()
                .HasOne(p => p.Doctor)
                .WithMany(v => v.Visitations)
                .HasForeignKey(fk => fk.PatientId);

            //Diagnoses
            modelBuilder
                .Entity<Diagnose>()
                .HasKey(k => k.DiagnoseId);

            modelBuilder
                .Entity<Diagnose>()
                .Property(p => p.Name)
                .IsUnicode();

            modelBuilder
                .Entity<Diagnose>()
                .Property(p => p.Comments)
                .IsUnicode();

            modelBuilder
                .Entity<Diagnose>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(fk => fk.PatientId);

            //PatientMedicaments
            modelBuilder
                .Entity<PatientMedicament>()
                .HasKey(pk => new {pk.PatientId, pk.MedicamentId});

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(fk=>fk.PatientId);

            modelBuilder
                .Entity<PatientMedicament>()
                .HasOne(p => p.Medicament)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(fk => fk.MedicamentId);

            //Medicaments
            modelBuilder
                .Entity<Medicament>()
                .HasKey(k => k.MedicamentId);

            modelBuilder
                .Entity<Medicament>()
                .Property(p => p.Name)
                .IsUnicode();
        }
    }
}
