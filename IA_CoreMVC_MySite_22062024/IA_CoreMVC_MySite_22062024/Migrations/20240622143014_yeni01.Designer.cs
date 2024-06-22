﻿// <auto-generated />
using System;
using IA_CoreMVC_MySite_22062024.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IA_CoreMVC_MySite_22062024.Migrations
{
    [DbContext(typeof(ProjeContext))]
    [Migration("20240622143014_yeni01")]
    partial class yeni01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IA_CoreMVC_MySite_22062024.Models.Entities.Hakkimda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Yazi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YaziFoto")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("YaziTarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Hakkimda");
                });

            modelBuilder.Entity("IA_CoreMVC_MySite_22062024.Models.Entities.Iletisim", b =>
                {
                    b.Property<int>("IletisimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IletisimID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IletisimID");

                    b.ToTable("Iletisims");
                });

            modelBuilder.Entity("IA_CoreMVC_MySite_22062024.Models.Entities.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KullaniciID"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Rolu")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullanicis");

                    b.HasData(
                        new
                        {
                            KullaniciID = 1,
                            Adi = "Ali",
                            KullaniciAdi = "aliyildiz",
                            Parola = "12345",
                            Rolu = "Admin",
                            Soyadi = "Yıldız"
                        },
                        new
                        {
                            KullaniciID = 2,
                            Adi = "Veli",
                            KullaniciAdi = "velican",
                            Parola = "1234",
                            Rolu = "User",
                            Soyadi = "Can"
                        });
                });

            modelBuilder.Entity("IA_CoreMVC_MySite_22062024.Models.Entities.Projeler", b =>
                {
                    b.Property<int>("ProjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjeID"), 1L, 1);

                    b.Property<string>("ProjeAciklamasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjeAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProjeFoto")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ProjeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjeID");

                    b.ToTable("Projelers");
                });
#pragma warning restore 612, 618
        }
    }
}