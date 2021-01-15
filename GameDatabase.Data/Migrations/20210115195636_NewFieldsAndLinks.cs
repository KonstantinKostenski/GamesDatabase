using Microsoft.EntityFrameworkCore.Migrations;

namespace GameDatabase.Data.Migrations
{
    public partial class NewFieldsAndLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameUser",
                columns: table => new
                {
                    FansId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavouriteGamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUser", x => new { x.FansId, x.FavouriteGamesId });
                    table.ForeignKey(
                        name: "FK_GameUser_AspNetUsers_FansId",
                        column: x => x.FansId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUser_Games_FavouriteGamesId",
                        column: x => x.FavouriteGamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameUser_FavouriteGamesId",
                table: "GameUser",
                column: "FavouriteGamesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameUser");
        }
    }
}
