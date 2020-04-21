using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneOtomasyonu.DataAccess.Migrations
{
    public partial class changePropName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastaneler_Iller_IlId",
                table: "Hastaneler");

            migrationBuilder.RenameColumn(
                name: "IlAdi",
                table: "Iller",
                newName: "ilAdi");

            migrationBuilder.RenameColumn(
                name: "IlId",
                table: "Iller",
                newName: "ilId");

            migrationBuilder.RenameColumn(
                name: "IlId",
                table: "Hastaneler",
                newName: "ilId");

            migrationBuilder.RenameIndex(
                name: "IX_Hastaneler_IlId",
                table: "Hastaneler",
                newName: "IX_Hastaneler_ilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hastaneler_Iller_ilId",
                table: "Hastaneler",
                column: "ilId",
                principalTable: "Iller",
                principalColumn: "ilId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hastaneler_Iller_ilId",
                table: "Hastaneler");

            migrationBuilder.RenameColumn(
                name: "ilAdi",
                table: "Iller",
                newName: "IlAdi");

            migrationBuilder.RenameColumn(
                name: "ilId",
                table: "Iller",
                newName: "IlId");

            migrationBuilder.RenameColumn(
                name: "ilId",
                table: "Hastaneler",
                newName: "IlId");

            migrationBuilder.RenameIndex(
                name: "IX_Hastaneler_ilId",
                table: "Hastaneler",
                newName: "IX_Hastaneler_IlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hastaneler_Iller_IlId",
                table: "Hastaneler",
                column: "IlId",
                principalTable: "Iller",
                principalColumn: "IlId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
