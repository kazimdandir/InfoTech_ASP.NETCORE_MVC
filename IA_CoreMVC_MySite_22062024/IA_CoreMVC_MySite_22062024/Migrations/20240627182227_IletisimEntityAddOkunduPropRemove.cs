using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA_CoreMVC_MySite_22062024.Migrations
{
    public partial class IletisimEntityAddOkunduPropRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Okundu",
                table: "Iletisims");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Okundu",
                table: "Iletisims",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
