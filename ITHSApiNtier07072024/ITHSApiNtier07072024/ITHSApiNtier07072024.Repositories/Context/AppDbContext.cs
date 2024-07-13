using ITHSApiNtier07072024.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHSApiNtier07072024.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=Api_NTier;Trusted_Connection=True;");
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
