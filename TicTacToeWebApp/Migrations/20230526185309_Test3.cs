using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToeWebApp.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_CrossPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ZeroPlayerId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "ZeroPlayerId",
                table: "Games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Games",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CrossPlayerId",
                table: "Games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_CrossPlayerId",
                table: "Games",
                column: "CrossPlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_ZeroPlayerId",
                table: "Games",
                column: "ZeroPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_CrossPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_ZeroPlayerId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "ZeroPlayerId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CrossPlayerId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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
    }
}
