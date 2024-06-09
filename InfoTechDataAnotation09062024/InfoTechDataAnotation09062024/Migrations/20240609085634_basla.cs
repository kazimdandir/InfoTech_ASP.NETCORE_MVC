using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoTechDataAnotation09062024.Migrations
{
    public partial class basla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    OgrNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrAd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OgrSoyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sinif = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Puan = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.OgrNo);
                });

            migrationBuilder.CreateTable(
                name: "Turs",
                columns: table => new
                {
                    TurNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turs", x => x.TurNo);
                });

            migrationBuilder.CreateTable(
                name: "Yazars",
                columns: table => new
                {
                    YazarNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YazarSoyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazars", x => x.YazarNo);
                });

            migrationBuilder.CreateTable(
                name: "Kitaps",
                columns: table => new
                {
                    KitapNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsbnNo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    KitapAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SayfaSayisi = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<byte>(type: "tinyint", nullable: false),
                    TurNo = table.Column<int>(type: "int", nullable: false),
                    YazarNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaps", x => x.KitapNo);
                    table.ForeignKey(
                        name: "FK_Kitaps_Turs_TurNo",
                        column: x => x.TurNo,
                        principalTable: "Turs",
                        principalColumn: "TurNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaps_Yazars_YazarNo",
                        column: x => x.YazarNo,
                        principalTable: "Yazars",
                        principalColumn: "YazarNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Islems",
                columns: table => new
                {
                    IslemNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrNo = table.Column<int>(type: "int", nullable: false),
                    KitapNo = table.Column<int>(type: "int", nullable: false),
                    ATarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islems", x => x.IslemNo);
                    table.ForeignKey(
                        name: "FK_Islems_Kitaps_KitapNo",
                        column: x => x.KitapNo,
                        principalTable: "Kitaps",
                        principalColumn: "KitapNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Islems_Ogrencis_OgrNo",
                        column: x => x.OgrNo,
                        principalTable: "Ogrencis",
                        principalColumn: "OgrNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Islems_KitapNo",
                table: "Islems",
                column: "KitapNo");

            migrationBuilder.CreateIndex(
                name: "IX_Islems_OgrNo",
                table: "Islems",
                column: "OgrNo");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_TurNo",
                table: "Kitaps",
                column: "TurNo");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaps_YazarNo",
                table: "Kitaps",
                column: "YazarNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Islems");

            migrationBuilder.DropTable(
                name: "Kitaps");

            migrationBuilder.DropTable(
                name: "Ogrencis");

            migrationBuilder.DropTable(
                name: "Turs");

            migrationBuilder.DropTable(
                name: "Yazars");
        }
    }
}
