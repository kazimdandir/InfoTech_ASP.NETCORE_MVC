using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InfoTechCoreMVCKutuphane02062024.Models
{
    public partial class KutuphaneContext : DbContext
    {
        public KutuphaneContext()
        {
        }

        public KutuphaneContext(DbContextOptions<KutuphaneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Islem> Islems { get; set; } = null!;
        public virtual DbSet<Kitap> Kitaps { get; set; } = null!;
        public virtual DbSet<Ogrenci> Ogrencis { get; set; } = null!;
        public virtual DbSet<Tur> Turs { get; set; } = null!;
        public virtual DbSet<Yazar> Yazars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=Kutuphane;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Islem>(entity =>
            {
                entity.HasKey(e => e.Islemno)
                    .HasName("PK__islem__32651BBAABD90092");

                entity.ToTable("islem");

                entity.Property(e => e.Islemno).HasColumnName("islemno");

                entity.Property(e => e.Atarih)
                    .HasColumnType("date")
                    .HasColumnName("atarih");

                entity.Property(e => e.Kitapno).HasColumnName("kitapno");

                entity.Property(e => e.Ogrno).HasColumnName("ogrno");

                entity.Property(e => e.Vtarih)
                    .HasColumnType("date")
                    .HasColumnName("vtarih");

                entity.HasOne(d => d.KitapnoNavigation)
                    .WithMany(p => p.Islems)
                    .HasForeignKey(d => d.Kitapno)
                    .HasConstraintName("FK__islem__kitapno__5165187F");

                entity.HasOne(d => d.OgrnoNavigation)
                    .WithMany(p => p.Islems)
                    .HasForeignKey(d => d.Ogrno)
                    .HasConstraintName("FK__islem__ogrno__52593CB8");
            });

            modelBuilder.Entity<Kitap>(entity =>
            {
                entity.HasKey(e => e.Kitapno)
                    .HasName("PK__Kitap__B964FD4EB3C375F6");

                entity.ToTable("Kitap");

                entity.Property(e => e.Kitapno).HasColumnName("kitapno");

                entity.Property(e => e.Isbnno).HasColumnName("isbnno");

                entity.Property(e => e.Kitapadi)
                    .HasMaxLength(50)
                    .HasColumnName("kitapadi");

                entity.Property(e => e.Sayfasayisi).HasColumnName("sayfasayisi");

                entity.Property(e => e.Turno).HasColumnName("turno");

                entity.Property(e => e.Yazarno).HasColumnName("yazarno");

                entity.HasOne(d => d.TurnoNavigation)
                    .WithMany(p => p.Kitaps)
                    .HasForeignKey(d => d.Turno)
                    .HasConstraintName("FK__Kitap__turno__534D60F1");

                entity.HasOne(d => d.YazarnoNavigation)
                    .WithMany(p => p.Kitaps)
                    .HasForeignKey(d => d.Yazarno)
                    .HasConstraintName("FK__Kitap__yazarno__5441852A");
            });

            modelBuilder.Entity<Ogrenci>(entity =>
            {
                entity.HasKey(e => e.Ogrno)
                    .HasName("PK__Ogrenci__591EB776C91716E0");

                entity.ToTable("Ogrenci");

                entity.Property(e => e.Ogrno).HasColumnName("ogrno");

                entity.Property(e => e.Cinsiyet)
                    .HasMaxLength(10)
                    .HasColumnName("cinsiyet");

                entity.Property(e => e.Dtarih)
                    .HasColumnType("date")
                    .HasColumnName("dtarih");

                entity.Property(e => e.Ograd)
                    .HasMaxLength(50)
                    .HasColumnName("ograd");

                entity.Property(e => e.Ogrsoyad)
                    .HasMaxLength(50)
                    .HasColumnName("ogrsoyad");

                entity.Property(e => e.Puan).HasColumnName("puan");

                entity.Property(e => e.Sinif)
                    .HasMaxLength(10)
                    .HasColumnName("sinif");
            });

            modelBuilder.Entity<Tur>(entity =>
            {
                entity.HasKey(e => e.Turno)
                    .HasName("PK__Tur__179B81C26444308C");

                entity.ToTable("Tur");

                entity.Property(e => e.Turno).HasColumnName("turno");

                entity.Property(e => e.Turadi)
                    .HasMaxLength(50)
                    .HasColumnName("turadi");
            });

            modelBuilder.Entity<Yazar>(entity =>
            {
                entity.HasKey(e => e.Yazarno)
                    .HasName("PK__Yazar__CCD376BDD0175528");

                entity.ToTable("Yazar");

                entity.Property(e => e.Yazarno).HasColumnName("yazarno");

                entity.Property(e => e.Yazarad)
                    .HasMaxLength(50)
                    .HasColumnName("yazarad");

                entity.Property(e => e.Yazarsoyad)
                    .HasMaxLength(50)
                    .HasColumnName("yazarsoyad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
