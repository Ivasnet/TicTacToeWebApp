using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeWebApp.Migrations
{
    public partial class DataAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrossPlayer",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ZeroPlayer",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "CrossPlayerId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZeroPlayerId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CrossPlayerId",
                table: "Games",
                column: "CrossPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ZeroPlayerId",
                table: "Games",
                column: "ZeroPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_CrossPlayerId",
                table: "Games",
                column: "CrossPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_ZeroPlayerId",
                table: "Games",
                column: "ZeroPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_CrossPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ZeroPlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CrossPlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ZeroPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CrossPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ZeroPlayerId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "CrossPlayer",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZeroPlayer",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
