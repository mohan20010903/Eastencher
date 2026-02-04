using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorTrack.Migrations
{
    /// <inheritdoc />
    public partial class Counterscolumnnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NcrCounter",
                table: "Counters",
                newName: "LastGeneratedNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastGeneratedNumber",
                table: "Counters",
                newName: "NcrCounter");
        }
    }
}
