using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroupWebApp.Migrations
{
    /// <inheritdoc />
    public partial class UserIdSetToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AspNetUsers_AppUserId1",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_AspNetUsers_AppUserId1",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_AppUserId1",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_AppUserId1",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Clubs");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Races",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_AppUserId",
                table: "Races",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AspNetUsers_AppUserId",
                table: "Clubs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AspNetUsers_AppUserId",
                table: "Races",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AspNetUsers_AppUserId",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_AspNetUsers_AppUserId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_AppUserId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_AppUserId",
                table: "Clubs");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Races",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Races",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Clubs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_AppUserId1",
                table: "Races",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_AppUserId1",
                table: "Clubs",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AspNetUsers_AppUserId1",
                table: "Clubs",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_AspNetUsers_AppUserId1",
                table: "Races",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
