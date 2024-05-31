using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonRehberiMVC.Migrations
{
    /// <inheritdoc />
    public partial class g4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bölüm",
                table: "Persons",
                newName: "Birim");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Birim",
                table: "Persons",
                newName: "Bölüm");
        }
    }
}
