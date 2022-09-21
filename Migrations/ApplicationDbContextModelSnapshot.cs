﻿// <auto-generated />
using System;
using CompanyMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyMvc.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("BusRouteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAvailable")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeatsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("BusId");

                    b.HasIndex("BusRouteId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("CompanyMvc.Models.BusRoute", b =>
                {
                    b.Property<int>("BusRouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("RouteTag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BusRouteId");

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

            modelBuilder.Entity("CompanyMvc.Models.Bus", b =>
                {
                    b.HasOne("CompanyMvc.Models.BusRoute", "BusRoute")
                        .WithMany("Bus")
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusRoute");
                });

            modelBuilder.Entity("CompanyMvc.Models.ApplicationUser", b =>
                {
                    b.Navigation("Booking")
                        .IsRequired();
                });

            modelBuilder.Entity("CompanyMvc.Models.BusRoute", b =>
                {
                    b.Navigation("Bus");
                });
#pragma warning restore 612, 618
        }
    }
}
