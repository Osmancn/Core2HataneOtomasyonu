using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneOtomasyonu.DataAccess.Migrations
{
    public partial class randevuAddIptal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Iptal",
                table: "Randevular",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iptal",
                table: "Randevular");
        }
    }
}
