using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfoTechCoreMVCCodeFirst08062024.Migrations
{
    public partial class DersVeEgitmenEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DersSaati = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.DersID);
                });

            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    EgitmenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.EgitmenID);
                });

            migrationBuilder.CreateTable(
                name: "DersEgitmen",
                columns: table => new
                {
                    DersID = table.Column<int>(type: "int", nullable: false),
                    EgitmenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersEgitmen", x => new { x.DersID, x.EgitmenID });
                    table.ForeignKey(
                        name: "FK_DersEgitmen_Dersler_DersID",
                        column: x => x.DersID,
                        principalTable: "Dersler",
                        principalColumn: "DersID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersEgitmen_Egitmenler_EgitmenID",
                        column: x => x.EgitmenID,
                        principalTable: "Egitmenler",
                        principalColumn: "EgitmenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersEgitmen_EgitmenID",
                table: "DersEgitmen",
                column: "EgitmenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersEgitmen");

            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "Egitmenler");
        }
    }
}
