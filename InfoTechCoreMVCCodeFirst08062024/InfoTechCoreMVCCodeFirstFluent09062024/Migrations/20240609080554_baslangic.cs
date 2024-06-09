using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoTechCoreMVCCodeFirstFluent09062024.Migrations
{
    public partial class baslangic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Egitmen",
                columns: table => new
                {
                    EgitmenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmen", x => x.EgitmenID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    CatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.CatID);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencilerimiz",
                columns: table => new
                {
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencilerimiz", x => x.OgrenciID);
                });

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitInStock = table.Column<short>(type: "smallint", nullable: true),
                    CatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Urunler_Kategoriler_CatID",
                        column: x => x.CatID,
                        principalTable: "Kategoriler",
                        principalColumn: "CatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciEgitmen",
                columns: table => new
                {
                    EgitmenID = table.Column<int>(type: "int", nullable: false),
                    OgrenciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciEgitmen", x => new { x.EgitmenID, x.OgrenciID });
                    table.ForeignKey(
                        name: "FK_OgrenciEgitmen_Egitmen_EgitmenID",
                        column: x => x.EgitmenID,
                        principalTable: "Egitmen",
                        principalColumn: "EgitmenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciEgitmen_Ogrencilerimiz_OgrenciID",
                        column: x => x.OgrenciID,
                        principalTable: "Ogrencilerimiz",
                        principalColumn: "OgrenciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciEgitmen_OgrenciID",
                table: "OgrenciEgitmen",
                column: "OgrenciID");

            migrationBuilder.CreateIndex(
                name: "IX_Urunler_CatID",
                table: "Urunler",
                column: "CatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciEgitmen");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropTable(
                name: "Egitmen");

            migrationBuilder.DropTable(
                name: "Ogrencilerimiz");

            migrationBuilder.DropTable(
                name: "Kategoriler");
        }
    }
}
