﻿using ENTITIES.Entities;
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
                optionsBuilder.UseSqlServer(@"Server=.;Database=HealthCareManagement;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientID)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorID)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Availability)
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AvailabilityID)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior

            modelBuilder.Entity<Availability>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Availabilities)
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired delete behavior
        }

    }
}
