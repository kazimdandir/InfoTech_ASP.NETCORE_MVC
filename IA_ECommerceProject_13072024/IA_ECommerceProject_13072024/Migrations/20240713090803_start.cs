using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA_ECommerceProject_13072024.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KategoriAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.KategoriID);
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
                    Rolu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "Uruns",
                columns: table => new
                {
                    UrunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UrunAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunFiyati = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UrunFoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RefKategoriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uruns", x => x.UrunID);
                    table.ForeignKey(
                        name: "FK_Uruns_Kategoris_RefKategoriID",
                        column: x => x.RefKategoriID,
                        principalTable: "Kategoris",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sipariss",
                columns: table => new
                {
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefKullaniciID = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TCKimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sipariss", x => x.SiparisID);
                    table.ForeignKey(
                        name: "FK_Sipariss_Kullanicis_RefKullaniciID",
                        column: x => x.RefKullaniciID,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepets",
                columns: table => new
                {
                    SepetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefKullaniciID = table.Column<int>(type: "int", nullable: false),
                    RefUrunID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepets", x => x.SepetID);
                    table.ForeignKey(
                        name: "FK_Sepets_Kullanicis_RefKullaniciID",
                        column: x => x.RefKullaniciID,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepets_Uruns_RefUrunID",
                        column: x => x.RefUrunID,
                        principalTable: "Uruns",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparisKalems",
                columns: table => new
                {
                    SiparisKalemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefSiparisID = table.Column<int>(type: "int", nullable: false),
                    RefUrunID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisKalems", x => x.SiparisKalemID);
                    table.ForeignKey(
                        name: "FK_SiparisKalems_Sipariss_RefSiparisID",
                        column: x => x.RefSiparisID,
                        principalTable: "Sipariss",
                        principalColumn: "SiparisID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparisKalems_Uruns_RefUrunID",
                        column: x => x.RefUrunID,
                        principalTable: "Uruns",
                        principalColumn: "UrunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategoris",
                columns: new[] { "KategoriID", "KategoriAciklamasi", "KategoriAdi" },
                values: new object[] { 1, "Elektronik Ürünler", "Elektronik" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciID", "Adi", "KullaniciAdi", "Parola", "Rolu", "Soyadi" },
                values: new object[] { 1, "Ali", "aliyilmaz", "12345", "Admin", "Yılmaz" });

            migrationBuilder.InsertData(
                table: "Uruns",
                columns: new[] { "UrunID", "RefKategoriID", "UrunAciklama", "UrunAdi", "UrunFiyati", "UrunFoto" },
                values: new object[] { 1, 1, "Test", "Laptop", 35000m, null });

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_RefKullaniciID",
                table: "Sepets",
                column: "RefKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepets_RefUrunID",
                table: "Sepets",
                column: "RefUrunID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKalems_RefSiparisID",
                table: "SiparisKalems",
                column: "RefSiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparisKalems_RefUrunID",
                table: "SiparisKalems",
                column: "RefUrunID");

            migrationBuilder.CreateIndex(
                name: "IX_Sipariss_RefKullaniciID",
                table: "Sipariss",
                column: "RefKullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_RefKategoriID",
                table: "Uruns",
                column: "RefKategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sepets");

            migrationBuilder.DropTable(
                name: "SiparisKalems");

            migrationBuilder.DropTable(
                name: "Sipariss");

            migrationBuilder.DropTable(
                name: "Uruns");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
