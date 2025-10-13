using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedtheDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ae2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6b"), "Medium" },
                    { new Guid("be2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6c"), "Hard" },
                    { new Guid("fe2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6a"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("12345678-1234-1234-1234-123456789abc"), "AKL", "Auckland", "https://www.earthtrekkers.com/wp-content/uploads/2023/10/Auckland-Itinerary.jpg.optimal.jpg" },
                    { new Guid("22345678-1234-1234-1234-123456789def"), "WLG", "Wellington", "https://res.klook.com/image/upload/fl_lossy.progressive,q_60/Mobile/City/yed8yyqbpif5ysgqg88m.jpg" },
                    { new Guid("32345678-1234-1234-1234-123456789012"), "CHC", "Christchurch", "https://www.lovoirbeauty.com/wp-content/uploads/2023/07/1-3.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ae2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("be2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fe2b3f5e-1d3c-4d3b-9c3a-1f2e3d4c5b6a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("12345678-1234-1234-1234-123456789abc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("22345678-1234-1234-1234-123456789def"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("32345678-1234-1234-1234-123456789012"));
        }
    }
}
