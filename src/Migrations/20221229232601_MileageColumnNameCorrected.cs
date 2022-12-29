using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroupWebApp.Migrations
{
    /// <inheritdoc />
    public partial class MileageColumnNameCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mileare",
                table: "AspNetUsers",
                newName: "Mileage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "AspNetUsers",
                newName: "Mileare");
        }
    }
}
