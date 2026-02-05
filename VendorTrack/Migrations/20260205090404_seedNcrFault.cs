using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendorTrack.Migrations
{
    /// <inheritdoc />
    public partial class seedNcrFault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NcrFaults",
                columns: new[] { "FaultId", "ActiveStatus", "FaultDescription" },
                values: new object[,]
                {
                    { 1, true, "Damage" },
                    { 2, true, "Dimension" },
                    { 3, true, "Others" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NcrFaults",
                keyColumn: "FaultId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NcrFaults",
                keyColumn: "FaultId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NcrFaults",
                keyColumn: "FaultId",
                keyValue: 3);
        }
    }
}
