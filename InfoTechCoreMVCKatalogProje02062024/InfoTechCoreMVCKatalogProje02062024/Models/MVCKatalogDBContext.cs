using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InfoTechCoreMVCKatalogProje02062024.Models
{
    public partial class MVCKatalogDBContext : DbContext
    {
        public MVCKatalogDBContext()
        {
        }

        public MVCKatalogDBContext(DbContextOptions<MVCKatalogDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategori> Kategoris { get; set; } = null!;
        public virtual DbSet<Urunler> Urunlers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=MVCKatalogDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KategoriAciklama).HasMaxLength(50);

                entity.Property(e => e.KategoriAdi).HasMaxLength(50);
            });

            modelBuilder.Entity<Urunler>(entity =>
            {
                entity.HasKey(e => e.UrunId);

                entity.ToTable("Urunler");

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.KategoriRefId).HasColumnName("KategoriRefID");

                entity.Property(e => e.UrunAciklama).HasMaxLength(50);

                entity.Property(e => e.UrunAdi).HasMaxLength(50);

                entity.Property(e => e.UrunFiyat).HasColumnType("money");

                entity.HasOne(d => d.KategoriRef)
                    .WithMany(p => p.Urunlers)
                    .HasForeignKey(d => d.KategoriRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Urunler_Kategori");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
