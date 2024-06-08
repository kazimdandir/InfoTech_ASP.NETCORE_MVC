﻿// <auto-generated />
using System;
using InfoTechCoreMVCCodeFirst08062024.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfoTechCoreMVCCodeFirst08062024.Migrations
{
    [DbContext(typeof(OrnekContext))]
    partial class OrnekContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DersEgitmen", b =>
                {
                    b.Property<int>("DersID")
                        .HasColumnType("int");

                    b.Property<int>("EgitmenID")
                        .HasColumnType("int");

                    b.HasKey("DersID", "EgitmenID");

                    b.HasIndex("EgitmenID");

                    b.ToTable("DersEgitmen");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Category", b =>
                {
                    b.Property<int>("CatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatID"), 1L, 1);

                    b.Property<string>("CatDescp")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("CatName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CatID");

                    b.ToTable("Kategori");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Ders", b =>
                {
                    b.Property<int>("DersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DersID"), 1L, 1);

                    b.Property<string>("DersAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<short>("DersSaati")
                        .HasColumnType("smallint");

                    b.HasKey("DersID");

                    b.ToTable("Dersler");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Egitmen", b =>
                {
                    b.Property<int>("EgitmenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EgitmenID"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EgitmenID");

                    b.ToTable("Egitmenler");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<int>("CatID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<short?>("UnitInStock")
                        .HasColumnType("smallint");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.HasIndex("CatID");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Student", b =>
                {
                    b.Property<int>("StudentNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentNo"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentNo");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.StudentAddress", b =>
                {
                    b.Property<int>("StudentAddressID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentAddressID");

                    b.ToTable("StudentAddress");
                });

            modelBuilder.Entity("DersEgitmen", b =>
                {
                    b.HasOne("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Ders", null)
                        .WithMany()
                        .HasForeignKey("DersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Egitmen", null)
                        .WithMany()
                        .HasForeignKey("EgitmenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Product", b =>
                {
                    b.HasOne("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.StudentAddress", b =>
                {
                    b.HasOne("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Student", "Student")
                        .WithOne("StudentAddress")
                        .HasForeignKey("InfoTechCoreMVCCodeFirst08062024.Models.Entities.StudentAddress", "StudentAddressID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("InfoTechCoreMVCCodeFirst08062024.Models.Entities.Student", b =>
                {
                    b.Navigation("StudentAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
