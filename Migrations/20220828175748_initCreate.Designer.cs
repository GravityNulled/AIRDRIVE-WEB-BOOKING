﻿// <auto-generated />
using CompanyMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyMvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220828175748_initCreate")]
    partial class initCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("CompanyMvc.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CompanyMvc.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApplicationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArrivalTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeputureTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookingId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.HasIndex("BusId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CompanyMvc.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BusNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeatsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("CompanyMvc.Models.BusRoute", b =>
                {
                    b.Property<int>("BusRouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BusRouteId");

                    b.HasIndex("BusId")
                        .IsUnique();

                    b.ToTable("BusRoutes");
                });

            modelBuilder.Entity("CompanyMvc.Models.Booking", b =>
                {
                    b.HasOne("CompanyMvc.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Booking")
                        .HasForeignKey("CompanyMvc.Models.Booking", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyMvc.Models.Bus", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("CompanyMvc.Models.BusRoute", b =>
                {
                    b.HasOne("CompanyMvc.Models.Bus", "Bus")
                        .WithOne("BusRoute")
                        .HasForeignKey("CompanyMvc.Models.BusRoute", "BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("CompanyMvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("Booking")
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyMvc.Models.Bus", b =>
                {
                    b.Navigation("BusRoute");
                });
#pragma warning restore 612, 618
        }
    }
}
