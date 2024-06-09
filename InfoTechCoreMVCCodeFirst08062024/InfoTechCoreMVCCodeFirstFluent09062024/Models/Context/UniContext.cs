using InfoTechCoreMVCCodeFirstFluent09062024.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoTechCoreMVCCodeFirstFluent09062024.Models.Context
{
    public class UniContext : DbContext
    {
        public UniContext()
        {

        }

        public UniContext(DbContextOptions<UniContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=InfoTechHSCodeFirstFluentDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            modelBuilder.Entity<Category>().HasKey(c => c.CatID); //PRIMARY KEY
            modelBuilder.Entity<Category>().Property(c => c.CatName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Category>().Property(c => c.Descp).HasColumnName("Description");
            modelBuilder.Entity<Category>().ToTable("Kategoriler");

            modelBuilder.Entity<Product>().HasKey(p => p.ProductID);
            modelBuilder.Entity<Product>().Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().ToTable("Urunler");

            //Bireçok ilişki
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(b => b.Product)
                .HasForeignKey(x => x.CatID);

            modelBuilder.Entity<Egitmen>().HasKey(e => e.EgitmenID);
            modelBuilder.Entity<Egitmen>().Property(e => e.EgitmenAdi).IsRequired().HasMaxLength(50).HasColumnName("Adi");
            modelBuilder.Entity<Egitmen>().Property(e => e.EgitmenSoyadi).IsRequired().HasMaxLength(50).HasColumnName("Soyadi");

            modelBuilder.Entity<Ogrenci>().HasKey(o => o.OgrenciID);
            modelBuilder.Entity<Ogrenci>().Property(o => o.OgrenciAdi).HasMaxLength(50).HasColumnName("Adi");
            modelBuilder.Entity<Ogrenci>().Property(o => o.OgrenciSoyadi).IsRequired().HasMaxLength(50).HasColumnName("Soyadi");
            modelBuilder.Entity<Ogrenci>().ToTable("Ogrencilerimiz");


            //Çokaçok ilişki
            modelBuilder.Entity<Ogrenci>()
                .HasMany(x => x.Egitmen)
                .WithMany(x => x.Ogrenci)
                .UsingEntity("OgrenciEgitmen");
        }
    }
}
