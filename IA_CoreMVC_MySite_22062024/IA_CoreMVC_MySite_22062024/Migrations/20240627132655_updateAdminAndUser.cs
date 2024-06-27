using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IA_CoreMVC_MySite_22062024.Migrations
{
    public partial class updateAdminAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kullanicis",
                keyColumn: "KullaniciID",
                keyValue: 1,
                columns: new[] { "Adi", "KullaniciAdi", "Soyadi" },
                values: new object[] { "Kazım İkbal", "admin", "Dandır" });

            migrationBuilder.UpdateData(
                table: "Kullanicis",
                keyColumn: "KullaniciID",
                keyValue: 2,
                columns: new[] { "Adi", "KullaniciAdi", "Parola", "Soyadi" },
                values: new object[] { "Kazım İkbal", "kazim", "12345", "Dandır" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kullanicis",
                keyColumn: "KullaniciID",
                keyValue: 1,
                columns: new[] { "Adi", "KullaniciAdi", "Soyadi" },
                values: new object[] { "Ali", "aliyildiz", "Yıldız" });

            migrationBuilder.UpdateData(
                table: "Kullanicis",
                keyColumn: "KullaniciID",
                keyValue: 2,
                columns: new[] { "Adi", "KullaniciAdi", "Parola", "Soyadi" },
                values: new object[] { "Veli", "velican", "1234", "Can" });
        }
    }
}
