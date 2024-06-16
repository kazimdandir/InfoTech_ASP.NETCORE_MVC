using IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IA_CoreMVC_FluentAPI_Repository_Library.Models.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAZIM\\SQLExpress;Database=IA_CoreMVC_FluentAPI_Repository_Library;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Writer

            modelBuilder.Entity<Writer>().HasKey(w => w.WriterID);
            modelBuilder.Entity<Writer>().Property(w => w.WriterName)
                                         .IsRequired()
                                         .HasMaxLength(50)
                                         .HasColumnName("Name");
            modelBuilder.Entity<Writer>().Property(w => w.WriterSurname)
                                         .IsRequired()
                                         .HasMaxLength(50)
                                         .HasColumnName("Surname");

            modelBuilder.Entity<Writer>()
                        .HasMany(w => w.Books)
                        .WithOne(b => b.Writer)
                        .HasForeignKey(b => b.WriterID)
                        .IsRequired(false);

            #endregion

            #region BookType

            modelBuilder.Entity<BookType>().HasKey(bt => bt.TypeID);
            modelBuilder.Entity<BookType>().Property(bt => bt.TypeName)
                                           .IsRequired()
                                           .HasMaxLength(50);

            #endregion

            #region Student

            modelBuilder.Entity<Student>().HasKey(s => s.StudentID);
            modelBuilder.Entity<Student>().Property(s => s.StudentName)
                                          .IsRequired()
                                          .HasMaxLength(50)
                                          .HasColumnName("Name");
            modelBuilder.Entity<Student>().Property(s => s.StudentSurname)
                                          .IsRequired()
                                          .HasMaxLength(50)
                                          .HasColumnName("Surname");
            modelBuilder.Entity<Student>().Property(s => s.Gender)
                                          .HasMaxLength(6);
            modelBuilder.Entity<Student>().Property(s => s.BirthDate)
                                          .HasColumnName("Birth Date");
            modelBuilder.Entity<Student>().Property(s => s.SchoolRoom)
                                          .IsRequired()
                                          .HasMaxLength(5)
                                          .HasColumnName("Class");
            modelBuilder.Entity<Student>().Property(s => s.Point)
                                          .IsRequired(false)
                                          .HasColumnType("smallint");            
            modelBuilder.Entity<Student>().HasCheckConstraint("CK_Student_Point", "[Point] >= 0 AND [Point] <= 100");

            modelBuilder.Entity<BookType>()
                .HasMany(bt => bt.Books)
                .WithOne(b => b.Type)
                .HasForeignKey(b => b.TypeID)
                .IsRequired(false);

            #endregion

            #region Book

            modelBuilder.Entity<Book>().HasKey(b => b.BookID);
            modelBuilder.Entity<Book>().Property(b => b.IsbnNo)
                                       .HasMaxLength(13);
            modelBuilder.Entity<Book>().Property(b => b.BookName)
                                       .IsRequired()
                                       .HasMaxLength(50)
                                       .HasColumnName("Book Name");
            modelBuilder.Entity<Book>().Property(b => b.WriterID)
                                       .HasColumnName("Writer");
            modelBuilder.Entity<Book>().Property(b => b.TypeID)
                                       .HasColumnName("Book Type");
            modelBuilder.Entity<Book>().Property(b => b.PageCount)
                                       .HasColumnName("Page Count");

            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Type)
                        .WithMany(bt => bt.Books)
                        .HasForeignKey(b => b.TypeID)
                        .IsRequired(false);
            #endregion

            #region Operation

            modelBuilder.Entity<Operation>().HasKey(o => o.OperationID);
            modelBuilder.Entity<Operation>().Property(o => o.StudentID)
                                            .HasColumnName("Student");
            modelBuilder.Entity<Operation>().Property(o => o.BookID)
                                            .HasColumnName("Book");
            modelBuilder.Entity<Operation>().Property(o => o.PurchaseDate)
                                            .IsRequired()
                                            .HasColumnName("Purchase Date")
                                            .HasColumnType("date");
            modelBuilder.Entity<Operation>().Property(o => o.DeliveryDate)
                                            .HasColumnName("Delivery Date")
                                            .HasColumnType("date");


            modelBuilder.Entity<Operation>()
                        .HasOne(o => o.Student)
                        .WithMany(s => s.Operations)
                        .HasForeignKey(o => o.StudentID)
                        .IsRequired(false);

            modelBuilder.Entity<Operation>()
                        .HasOne(o => o.Book)
                        .WithMany(s => s.Operations)
                        .HasForeignKey(o => o.BookID)
                        .IsRequired(false);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities.Writer>? Writer { get; set; }

        public DbSet<IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities.BookType>? BookType { get; set; }

        public DbSet<IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities.Student>? Student { get; set; }

        public DbSet<IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities.Book>? Book { get; set; }

        public DbSet<IA_CoreMVC_FluentAPI_Repository_Library.Models.Entities.Operation>? Operation { get; set; }
    }
}
