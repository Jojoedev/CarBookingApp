﻿// <auto-generated />
using System;
using CarBookingDataLibrary.Migrations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarBookingDataLibrary.Migrations
{
    [DbContext(typeof(CarApplicationDbContext))]
    [Migration("20230601225338_AddMakeModelRelationship")]
    partial class AddMakeModelRelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarBookingDataLibrary.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int?>("ColourId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfDriver")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("ColourId");

                    b.HasIndex("MakeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarBookingDataLibrary.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("CarBookingDataLibrary.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colours");
                });

            modelBuilder.Entity("CarBookingDataLibrary.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("CarBookingDataLibrary.Car", b =>
                {
                    b.HasOne("CarBookingDataLibrary.CarModel", "CarModel")
                        .WithMany("Cars")
                        .HasForeignKey("CarModelId");

                    b.HasOne("CarBookingDataLibrary.Colour", "Colour")
                        .WithMany()
                        .HasForeignKey("ColourId");

                    b.HasOne("CarBookingDataLibrary.Make", "Make")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId");

                    b.Navigation("CarModel");

                    b.Navigation("Colour");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("CarBookingDataLibrary.CarModel", b =>
                {
                    b.HasOne("CarBookingDataLibrary.Make", "Make")
                        .WithMany("CarModel")
                        .HasForeignKey("MakeId");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("CarBookingDataLibrary.CarModel", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarBookingDataLibrary.Make", b =>
                {
                    b.Navigation("CarModel");

                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
