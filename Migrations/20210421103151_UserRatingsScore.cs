using Microsoft.EntityFrameworkCore.Migrations;

namespace meistrelis.Migrations
{
    public partial class UserRatingsScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "UserRatings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "UserRatings");
        }
    }
}
