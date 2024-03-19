﻿using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ENTITIES.Context
{
    public class PatientBookingContext : DbContext
    {
        public PatientBookingContext() :base()
        {
        }

        public PatientBookingContext(DbContextOptions<PatientBookingContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=HealthCareManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Availabilities> Availabilities { get; set; }
        //public DbSet<Availability2> Availabilities2 { get; set; }
        public DbSet<DoctorAvailability> DoctorAvailability { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
