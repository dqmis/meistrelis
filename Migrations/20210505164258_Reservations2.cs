using Microsoft.EntityFrameworkCore.Migrations;

namespace meistrelis.Migrations
{
    public partial class Reservations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserServices",
                table: "UserServices");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserServices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserServices",
                table: "UserServices",
                columns: new[] { "UserId", "ServiceId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserServices",
                table: "UserServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserServices",
                table: "UserServices",
                columns: new[] { "UserId", "ServiceId" });
        }
    }
}
