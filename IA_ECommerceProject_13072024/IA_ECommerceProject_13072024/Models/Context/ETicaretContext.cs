using IA_ECommerceProject_13072024.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IA_ECommerceProject_13072024.Models.Context
{
    public class ETicaretContext : DbContext
    {
        public ETicaretContext()
        {

        }

        public ETicaretContext(DbContextOptions<ETicaretContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=IA_ETicaretProject;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data

            modelBuilder.Entity<Kullanici>()
                .HasData(
                    new Kullanici { KullaniciID = 1, Adi = "Ali", Soyadi = "Yılmaz", KullaniciAdi = "aliyilmaz", Parola = "12345", Rolu = "Admin" }
                );

            modelBuilder.Entity<Kategori>()
                .HasData(
                    new Kategori { KategoriID = 1, KategoriAdi = "Elektronik", KategoriAciklamasi = "Elektronik Ürünler" }
                );

            modelBuilder.Entity<Urun>()
                .HasData(
                    new Urun { UrunID = 1, UrunAdi = "Laptop", UrunAciklama = "Test", UrunFiyati = 35000, RefKategoriID = 1 }
                );
        }

        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Urun> Uruns { get; set; }
        public virtual DbSet<Sepet> Sepets { get; set; }
        public virtual DbSet<Siparis> Sipariss { get; set; }
        public virtual DbSet<SiparisKalem> SiparisKalems { get; set; }
    }
}
