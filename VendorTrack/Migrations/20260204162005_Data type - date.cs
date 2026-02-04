using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorTrack.Migrations
{
    /// <inheritdoc />
    public partial class Datatypedate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "ReceivedDate",
                table: "VendorNcrs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceivedDate",
                table: "VendorNcrs",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
