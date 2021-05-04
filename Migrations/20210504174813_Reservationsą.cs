using Microsoft.EntityFrameworkCore.Migrations;

namespace meistrelis.Migrations
{
    public partial class Reservationsą : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_UserServices_UserId_ServiceId",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_UserServices_UserId_ServiceId",
                table: "Reservations",
                columns: new[] { "UserId", "ServiceId" },
                principalTable: "UserServices",
                principalColumns: new[] { "UserId", "ServiceId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
