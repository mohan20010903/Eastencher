using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorTrack.Migrations
{
    /// <inheritdoc />
    public partial class CountersforNCRNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorNcr",
                table: "VendorNcr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NcrFault",
                table: "NcrFault");

            migrationBuilder.RenameTable(
                name: "VendorNcr",
                newName: "VendorNcrs");

            migrationBuilder.RenameTable(
                name: "NcrFault",
                newName: "NcrFaults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorNcrs",
                table: "VendorNcrs",
                column: "VendorNcrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NcrFaults",
                table: "NcrFaults",
                column: "FaultId");

            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reference = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NcrCounter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorNcrs",
                table: "VendorNcrs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NcrFaults",
                table: "NcrFaults");

            migrationBuilder.RenameTable(
                name: "VendorNcrs",
                newName: "VendorNcr");

            migrationBuilder.RenameTable(
                name: "NcrFaults",
                newName: "NcrFault");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorNcr",
                table: "VendorNcr",
                column: "VendorNcrId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NcrFault",
                table: "NcrFault",
                column: "FaultId");
        }
    }
}
