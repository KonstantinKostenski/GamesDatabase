using Microsoft.EntityFrameworkCore.Migrations;

namespace GameDatabase.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GenreId",
                table: "Games",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Key = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Games");
        }
    }
}
