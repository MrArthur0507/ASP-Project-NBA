using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectData.Migrations
{
    /// <inheritdoc />
    public partial class Comments2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Players_PlayerId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Teams_TeamId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PlayerId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TeamId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PlayerId",
                table: "Comments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TeamId",
                table: "Comments",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Players_PlayerId",
                table: "Comments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Teams_TeamId",
                table: "Comments",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
