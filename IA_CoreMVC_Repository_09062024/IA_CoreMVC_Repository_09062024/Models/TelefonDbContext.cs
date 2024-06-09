using Microsoft.EntityFrameworkCore;

namespace IA_CoreMVC_Repository_09062024.Models
{
    public class TelefonDbContext : DbContext
    {
        public TelefonDbContext()
        {

        }

        public virtual DbSet<Kisiler> Kisilers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=InfoTechRepositoryDB;Trusted_Connection=True;");
        }
    }
}
