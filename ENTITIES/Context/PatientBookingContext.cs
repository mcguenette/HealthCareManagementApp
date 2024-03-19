using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Context
{
    public class PatientBookingContext : DbContext
    {
        public PatientBookingContext() : base()
        {

        }
        public PatientBookingContext(DbContextOptions<PatientBookingContext> options) : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=HealthCareManagementApp;Trusted_Connection=True;MultipleActiveResultSets=true;");
                Console.WriteLine("Database connection configured.");
            }
        }

        
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Availabilities> Availabilities { get; set; }
        public DbSet<Availability2> Availabilities2 { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Patients)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Doctors)
                .WithMany(d => d.Bookings)
                .OnDelete(DeleteBehavior.NoAction);// Configure Doctor relationship without cascade behavior

            modelBuilder.Entity<Bookings>()
                .HasOne(b => b.Availabilities)
                .WithMany(a => a.Bookings) // Configure Availability relationship without cascade behavior
                .OnDelete(DeleteBehavior.NoAction);
            
             modelBuilder.Entity<Availabilities>()
                .HasOne(a => a.Doctors)
                .WithMany(d => d.Availabilities)
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }

    }
}
