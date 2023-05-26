﻿// <auto-generated />
using System;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Migrations
{
    [DbContext(typeof(HotelDBContext))]
    [Migration("20230526062549_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotel.Models.Customer", b =>
                {
                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Hotel.Models.HotelTable", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Hotel.Models.Reservation", b =>
                {
                    b.Property<int>("reservation_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("check_in_date")
                        .HasColumnType("Date");

                    b.Property<DateTime>("check_out_date")
                        .HasColumnType("Date");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<int?>("customer_id1")
                        .HasColumnType("int");

                    b.Property<int>("room_id")
                        .HasColumnType("int");

                    b.Property<int?>("room_id1")
                        .HasColumnType("int");

                    b.HasKey("reservation_id");

                    b.HasIndex("customer_id1");

                    b.HasIndex("room_id1");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Hotel.Models.Room", b =>
                {
                    b.Property<int>("room_id")
                        .HasColumnType("int");

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelTableHotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("room_id");

                    b.HasIndex("HotelTableHotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hotel.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hotel.Models.Reservation", b =>
                {
                    b.HasOne("Hotel.Models.Customer", null)
                        .WithMany("Reservations")
                        .HasForeignKey("customer_id1");

                    b.HasOne("Hotel.Models.Room", null)
                        .WithMany("Reservations")
                        .HasForeignKey("room_id1");
                });

            modelBuilder.Entity("Hotel.Models.Room", b =>
                {
                    b.HasOne("Hotel.Models.HotelTable", null)
                        .WithMany("Rooms")
                        .HasForeignKey("HotelTableHotelId");
                });

            modelBuilder.Entity("Hotel.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Hotel.Models.HotelTable", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotel.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
