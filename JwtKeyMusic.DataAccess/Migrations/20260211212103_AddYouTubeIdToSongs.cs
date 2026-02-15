using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtKeyMusic.DataAccess.Migrations
{
    public partial class AddYouTubeIdToSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YouTubeId",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YouTubeId",
                table: "Songs");
        }
    }
}
