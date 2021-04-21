using Microsoft.EntityFrameworkCore.Migrations;

namespace meistrelis.Migrations
{
    public partial class UserRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    RatedUserId = table.Column<int>(type: "integer", nullable: false),
                    ReviewerId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => new { x.RatedUserId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_RatedUserId",
                        column: x => x.RatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRatings_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_ReviewerId",
                table: "UserRatings",
                column: "ReviewerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRatings");
        }
    }
}
