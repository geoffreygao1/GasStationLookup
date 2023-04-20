﻿// <auto-generated />
using System;
using GasStationLookupApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GasStationLookupApi.Migrations
{
    [DbContext(typeof(GasStationLookupApiContext))]
    [Migration("20230420063709_UpdatedJSON")]
    partial class UpdatedJSON
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GasStationLookupApi.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GasStationLookupApi.Models.GasPrice", b =>
                {
                    b.Property<int>("GasPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("Diesel")
                        .HasColumnType("float");

                    b.Property<float>("Premium")
                        .HasColumnType("float");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<float>("Unleaded")
                        .HasColumnType("float");

                    b.HasKey("GasPriceId");

                    b.HasIndex("StationId");

                    b.ToTable("GasPrices");
                });

            modelBuilder.Entity("GasStationLookupApi.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("StationId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("GasStationLookupApi.Models.GasPrice", b =>
                {
                    b.HasOne("GasStationLookupApi.Models.Station", "Station")
                        .WithMany("GasPrices")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });

            modelBuilder.Entity("GasStationLookupApi.Models.Station", b =>
                {
                    b.HasOne("GasStationLookupApi.Models.Company", "Company")
                        .WithMany("Stations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("GasStationLookupApi.Models.Company", b =>
                {
                    b.Navigation("Stations");
                });

            modelBuilder.Entity("GasStationLookupApi.Models.Station", b =>
                {
                    b.Navigation("GasPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
