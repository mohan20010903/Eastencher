using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorTrack.Migrations
{
    /// <inheritdoc />
    public partial class FaultEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorNcrDTO");

            migrationBuilder.CreateTable(
                name: "NcrFault",
                columns: table => new
                {
                    FaultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fault = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NcrFault", x => x.FaultId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NcrFault");

            migrationBuilder.CreateTable(
                name: "VendorNcrDTO",
                columns: table => new
                {
                    VendorNcrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fault = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NcrNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NonConformingQuantity = table.Column<int>(type: "int", nullable: false),
                    PartNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ReceivedQuantity = table.Column<int>(type: "int", nullable: false),
                    VendorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorNcrDTO", x => x.VendorNcrId);
                });
        }
    }
}
