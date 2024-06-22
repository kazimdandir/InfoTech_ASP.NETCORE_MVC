using IA_CoreMVC_MySite_22062024.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace IA_CoreMVC_MySite_22062024.Models.Context
{
    public class ProjeContext : DbContext
    {
        public ProjeContext()
        {

        }

        public ProjeContext(DbContextOptions<ProjeContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=IA_CoreMVC_MySite;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed data

            modelBuilder.Entity<Kullanici>()
                .HasData(
                new Kullanici { KullaniciID = 1, Adi = "Ali", Soyadi = "Yıldız", KullaniciAdi = "aliyildiz", Parola = "12345", Rolu = "Admin" },
                new Kullanici { KullaniciID = 2, Adi = "Veli", Soyadi = "Can", KullaniciAdi = "velican", Parola = "1234", Rolu = "User" }
                );
        }

        public virtual DbSet<Hakkimda> Hakkimda { get; set; }
        public virtual DbSet<Projeler> Projelers { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
    }
}
