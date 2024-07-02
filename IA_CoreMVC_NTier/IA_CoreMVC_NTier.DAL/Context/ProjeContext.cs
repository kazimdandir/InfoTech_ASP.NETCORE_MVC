using IA_CoreMVC_NTier.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_CoreMVC_NTier.DAL.Context
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
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=IA_KatmanliMimari;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(a => a.CategoryID);
            modelBuilder.Entity<Category>()
                .Property(a => a.CategoryName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
            modelBuilder.Entity<Product>()
                .Property(a => a.ProductName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(x => x.CategoryId);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}



