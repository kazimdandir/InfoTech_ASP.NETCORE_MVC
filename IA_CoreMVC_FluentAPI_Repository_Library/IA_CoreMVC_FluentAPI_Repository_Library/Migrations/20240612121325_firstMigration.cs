using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA_CoreMVC_FluentAPI_Repository_Library.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BirthDate = table.Column<DateTime>(name: "Birth Date", type: "datetime2", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Point = table.Column<short>(type: "smallint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.CheckConstraint("CK_Student_Point", "[Point] >= 0 AND [Point] <= 100");
                });

            migrationBuilder.CreateTable(
                name: "Writer",
                columns: table => new
                {
                    WriterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer", x => x.WriterID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsbnNo = table.Column<long>(type: "bigint", maxLength: 13, nullable: true),
                    BookName = table.Column<string>(name: "Book Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Writer = table.Column<int>(type: "int", nullable: true),
                    BookType = table.Column<int>(name: "Book Type", type: "int", nullable: true),
                    PageCount = table.Column<int>(name: "Page Count", type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Book_BookType_Book Type",
                        column: x => x.BookType,
                        principalTable: "BookType",
                        principalColumn: "TypeID");
                    table.ForeignKey(
                        name: "FK_Book_Writer_Writer",
                        column: x => x.Writer,
                        principalTable: "Writer",
                        principalColumn: "WriterID");
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    OperationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Student = table.Column<int>(type: "int", nullable: true),
                    Book = table.Column<int>(type: "int", nullable: true),
                    PurchaseDate = table.Column<DateTime>(name: "Purchase Date", type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(name: "Delivery Date", type: "datetime2", nullable: true),
                    IsDelivered = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationID);
                    table.ForeignKey(
                        name: "FK_Operation_Book_Book",
                        column: x => x.Book,
                        principalTable: "Book",
                        principalColumn: "BookID");
                    table.ForeignKey(
                        name: "FK_Operation_Student_Student",
                        column: x => x.Student,
                        principalTable: "Student",
                        principalColumn: "StudentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Book Type",
                table: "Book",
                column: "Book Type");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Writer",
                table: "Book",
                column: "Writer");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_Book",
                table: "Operation",
                column: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_Student",
                table: "Operation",
                column: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Writer");
        }
    }
}
