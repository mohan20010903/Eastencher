using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorTrack.Migrations
{
    /// <inheritdoc />
    public partial class Faultcolumnnamechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fault",
                table: "NcrFault",
                newName: "FaultDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaultDescription",
                table: "NcrFault",
                newName: "Fault");
        }
    }
}
