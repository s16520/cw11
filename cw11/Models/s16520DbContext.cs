using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class s16520DbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }



        public s16520DbContext() { }
        public s16520DbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Prescription_Medicament>()
                .HasKey(c => new { c.IdMedicament, c.IdPrescription });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            List<Doctor> doctors = new List<Doctor>();

            doctors.Add(new Doctor { IdDoctor=1, FirstName="Grzegorz", LastName="Nowak", Email="nowak@lekarz.pl" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Janusz", LastName = "Kowalski", Email = "kowalski@lekarz.pl" });

            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient { IdPatient=1, FirstName="Magdalena", LastName="Niewiara", BirthDate=new DateTime(1980,3,12) });
            patients.Add(new Patient { IdPatient = 2, FirstName = "Katarzyna", LastName = "Kominiarska", BirthDate = new DateTime(1988, 6, 7) });

            List<Medicament> medicaments = new List<Medicament>();

            medicaments.Add(new Medicament { IdMedicament = 1, Name = "Xertix 330mg", Description = "Lek na zatoki", Type = "Bez recepty" });
            medicaments.Add(new Medicament { IdMedicament = 2, Name = "Zabekk krople 20ml", Description = "Krople do oczu", Type = "Bez recepty" });
            medicaments.Add(new Medicament { IdMedicament = 3, Name = "NeuroMatrix 20mg", Description = "Lek na uspokojenie", Type = "Na receptę" });

            List<Prescription> prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription { IdPrescription = 1, IdDoctor = 1, IdPatient = 1, Data = new DateTime(2020, 3, 4), DueDate = new DateTime(2020, 3, 6) });

            List<Prescription_Medicament> prescription_Medicaments = new List<Prescription_Medicament>();

            prescription_Medicaments.Add(new Prescription_Medicament { IdPrescription = 1, IdMedicament = 1, Dose = 1, Details = "Łyżka" });

            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Medicament>().HasData(medicaments);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<Prescription_Medicament>().HasData(prescription_Medicaments);


        }
    }
}
