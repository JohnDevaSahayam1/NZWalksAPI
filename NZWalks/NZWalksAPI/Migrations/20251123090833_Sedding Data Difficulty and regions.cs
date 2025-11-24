using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeddingDataDifficultyandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7534ec97-b24d-4860-b620-5fbd816069fa"), "Hard" },
                    { new Guid("7c5d53ce-37c8-46e4-a407-57b51c5dc119"), "Easy" },
                    { new Guid("e28d526e-8129-4cab-a0ac-14d18c0e048f"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("21630836-6b4b-489e-889f-a3a2d676c929"), "CHC", "Christchurch", null },
                    { new Guid("4590b8cc-d107-4ac9-b2ce-45180e0d1017"), "WLG", "Wellington", null },
                    { new Guid("dd765a99-411e-43f1-a9f5-92d249112cce"), "QWE", "Queentown", null },
                    { new Guid("f8592128-1bf1-4f12-8f54-61d3f7f43f34"), "AKL", "Auckland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7534ec97-b24d-4860-b620-5fbd816069fa"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7c5d53ce-37c8-46e4-a407-57b51c5dc119"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e28d526e-8129-4cab-a0ac-14d18c0e048f"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("21630836-6b4b-489e-889f-a3a2d676c929"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("4590b8cc-d107-4ac9-b2ce-45180e0d1017"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("dd765a99-411e-43f1-a9f5-92d249112cce"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("f8592128-1bf1-4f12-8f54-61d3f7f43f34"));
        }
    }
}
