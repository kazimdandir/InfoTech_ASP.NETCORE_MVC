using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA_CoreMVC_MySite_22062024.Migrations
{
    public partial class IletisimEntityAddTarihProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "Iletisims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "Iletisims");
        }
    }
}
