using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeWebApp.Migrations
{
    public partial class add_AppUser20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_Id",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_UserId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Players",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_Id",
                table: "Players",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
