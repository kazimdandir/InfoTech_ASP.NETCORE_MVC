using InfoTechCoreMVCCodeFirst08062024.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoTechCoreMVCCodeFirst08062024.Models.Context
{
    public class OrnekContext : DbContext
    {
        //database initialize
        public OrnekContext()
        {

        }

        public OrnekContext(DbContextOptions<OrnekContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=InfoTechHSOrnekDB;Trusted_Connection=True;");
        }

        public DbSet<Category> Kategori { get; set; }
        public DbSet<Product> Urunler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Egitmen> Egitmenler { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }


        //fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
