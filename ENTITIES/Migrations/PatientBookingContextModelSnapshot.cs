﻿// <auto-generated />
using System;
using ENTITIES.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ENTITIES.Migrations
{
    [DbContext(typeof(PatientBookingContext))]
    partial class PatientBookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ENTITIES.Entities.Availabilities", b =>
                {
                    b.Property<int>("AvailabilityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailabilityID"));

                    b.Property<DateTime>("AvailabilityTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("DoctorsDoctorID")
                        .HasColumnType("int");

                    b.HasKey("AvailabilityID");

                    b.HasIndex("DoctorsDoctorID");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("ENTITIES.Entities.Bookings", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<int>("AvailabilityID")
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("AvailabilityID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ENTITIES.Entities.DoctorAvailability", b =>
                {
                    b.Property<int>("DoctorAvailibilityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorAvailibilityID"));

                    b.Property<int>("AvailabilityID")
                        .HasColumnType("int");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("DoctorsDoctorID")
                        .HasColumnType("int");

                    b.HasKey("DoctorAvailibilityID");

                    b.HasIndex("AvailabilityID");

                    b.HasIndex("DoctorsDoctorID");

                    b.ToTable("DoctorAvailability");
                });

            modelBuilder.Entity("ENTITIES.Entities.Doctors", b =>
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

            modelBuilder.Entity("ENTITIES.Entities.Patients", b =>
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

            modelBuilder.Entity("ENTITIES.Entities.Availabilities", b =>
                {
                    b.HasOne("ENTITIES.Entities.Doctors", "Doctors")
                        .WithMany("Availabilities")
                        .HasForeignKey("DoctorsDoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("ENTITIES.Entities.Bookings", b =>
                {
                    b.HasOne("ENTITIES.Entities.Availabilities", "Availabilities")
                        .WithMany()
                        .HasForeignKey("AvailabilityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENTITIES.Entities.Doctors", "Doctors")
                        .WithMany("Bookings")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENTITIES.Entities.Patients", "Patients")
                        .WithMany("Bookings")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Availabilities");

                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("ENTITIES.Entities.DoctorAvailability", b =>
                {
                    b.HasOne("ENTITIES.Entities.Availabilities", "Availabilities")
                        .WithMany("DoctorAvailabilities")
                        .HasForeignKey("AvailabilityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ENTITIES.Entities.Doctors", "Doctors")
                        .WithMany("DoctorAvailabilities")
                        .HasForeignKey("DoctorsDoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Availabilities");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("ENTITIES.Entities.Availabilities", b =>
                {
                    b.Navigation("DoctorAvailabilities");
                });

            modelBuilder.Entity("ENTITIES.Entities.Doctors", b =>
                {
                    b.Navigation("Availabilities");

                    b.Navigation("Bookings");

                    b.Navigation("DoctorAvailabilities");
                });

            modelBuilder.Entity("ENTITIES.Entities.Patients", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
