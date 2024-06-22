using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA_CoreMVC_MySite_22062024.Migrations
{
    public partial class yeni01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hakkimda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Yazi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YaziTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YaziFoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkimda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iletisims",
                columns: table => new
                {
                    IletisimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisims", x => x.IletisimID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rolu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Projelers",
                columns: table => new
                {
                    ProjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjeAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjeFoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projelers", x => x.ProjeID);
                });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciID", "Adi", "KullaniciAdi", "Parola", "Rolu", "Soyadi" },
                values: new object[] { 1, "Ali", "aliyildiz", "12345", "Admin", "Yıldız" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciID", "Adi", "KullaniciAdi", "Parola", "Rolu", "Soyadi" },
                values: new object[] { 2, "Veli", "velican", "1234", "User", "Can" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hakkimda");

            migrationBuilder.DropTable(
                name: "Iletisims");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "Projelers");
        }
    }
}
