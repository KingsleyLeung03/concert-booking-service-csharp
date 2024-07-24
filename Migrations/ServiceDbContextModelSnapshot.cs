﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using concert_booking_service_csharp.Data;

#nullable disable

namespace concert_booking_service_csharp.Migrations
{
    [DbContext(typeof(ServiceDbContext))]
    partial class ServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("ConcertPerformer", b =>
                {
                    b.Property<long>("ConcertsConcertId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PerformersPerformerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ConcertsConcertId", "PerformersPerformerId");

                    b.HasIndex("PerformersPerformerId");

                    b.ToTable("ConcertPerformer");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Admin", b =>
                {
                    b.Property<long>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<long>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Booking", b =>
                {
                    b.Property<long>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ConcertId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookingId");

                    b.HasIndex("ConcertId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Concert", b =>
                {
                    b.Property<long>("ConcertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Blurb")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ConcertId");

                    b.ToTable("Concerts");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.ConcertDate", b =>
                {
                    b.Property<long>("ConcertDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ConcertId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("ConcertDateId");

                    b.HasIndex("ConcertId");

                    b.ToTable("ConcertDates");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Performer", b =>
                {
                    b.Property<long>("PerformerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Blurb")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("Genre")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PerformerId");

                    b.ToTable("Performers");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Seat", b =>
                {
                    b.Property<long>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("BookingId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SeatId");

                    b.HasIndex("BookingId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<long>("Version")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConcertPerformer", b =>
                {
                    b.HasOne("concert_booking_service_csharp.Models.Concert", null)
                        .WithMany()
                        .HasForeignKey("ConcertsConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("concert_booking_service_csharp.Models.Performer", null)
                        .WithMany()
                        .HasForeignKey("PerformersPerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Booking", b =>
                {
                    b.HasOne("concert_booking_service_csharp.Models.Concert", "Concert")
                        .WithMany()
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("concert_booking_service_csharp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.ConcertDate", b =>
                {
                    b.HasOne("concert_booking_service_csharp.Models.Concert", "Concert")
                        .WithMany("ConcertDates")
                        .HasForeignKey("ConcertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concert");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Seat", b =>
                {
                    b.HasOne("concert_booking_service_csharp.Models.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingId");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Booking", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("concert_booking_service_csharp.Models.Concert", b =>
                {
                    b.Navigation("ConcertDates");
                });
#pragma warning restore 612, 618
        }
    }
}
