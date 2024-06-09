using InfoTechDataAnotation09062024.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoTechDataAnotation09062024.Models.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=InfoTechLibraryDataAnnotationDB;Trusted_Connection=True;");
        }

        public virtual DbSet<Ogrenci> Ogrencis { get; set; }
        public virtual DbSet<Kitap> Kitaps { get; set; }
        public virtual DbSet<Islem> Islems { get; set; }
        public virtual DbSet<Tur> Turs { get; set; }
        public virtual DbSet<Yazar> Yazars { get; set; }
    }
}
