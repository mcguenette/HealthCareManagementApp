﻿// <auto-generated />
using System;
using ENTITIES.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENTITIES.Migrations
{
    [DbContext(typeof(PatientBookingContext))]
    [Migration("20240319021434_BEFCore10")]
    partial class BEFCore10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ENTITIES.Entities.Availability", b =>
                {
                    b.Property<int>("AvailabilityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailabilityID"));

                    b.Property<DateTime>("AvailabilityDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AvailabilityTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.HasKey("AvailabilityID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("ENTITIES.Entities.Availability2", b =>
                {
                    b.Property<int>("AvailabilityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailabilityID"));

                    b.Property<DateTime>("AvailabilityTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AvailabilityID");

                    b.ToTable("Availabilities2");
                });

            modelBuilder.Entity("ENTITIES.Entities.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<int?>("Availability2AvailabilityID")
                        .HasColumnType("int");

                    b.Property<int>("AvailabilityID")
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("Availability2AvailabilityID");

                    b.HasIndex("AvailabilityID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ENTITIES.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorID"));

                    b.Property<string>("DoctorEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DoctorSpecialization")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DoctorID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ENTITIES.Entities.Patient", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ENTITIES.Entities.Availability", b =>
                {
                    b.HasOne("ENTITIES.Entities.Doctor", "Doctor")
                        .WithMany("Availabilities")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("ENTITIES.Entities.Booking", b =>
                {
                    b.HasOne("ENTITIES.Entities.Availability2", null)
                        .WithMany("Bookings")
                        .HasForeignKey("Availability2AvailabilityID");

                    b.HasOne("ENTITIES.Entities.Availability", "Availability")
                        .WithMany("Bookings")
                        .HasForeignKey("AvailabilityID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ENTITIES.Entities.Doctor", "Doctor")
                        .WithMany("Bookings")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ENTITIES.Entities.Patient", "Patient")
                        .WithMany("Bookings")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Availability");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ENTITIES.Entities.Availability", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("ENTITIES.Entities.Availability2", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("ENTITIES.Entities.Doctor", b =>
                {
                    b.Navigation("Availabilities");

                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("ENTITIES.Entities.Patient", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
