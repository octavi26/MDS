using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedDataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"),
                column: "Icon",
                value: "♨️");

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), "A basic earth element", "🌱", true, "Earth" },
                    { new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"), "Fine particles", "🌫️", false, "Dust" },
                    { new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"), "Water falling from the sky", "🌧️", false, "Rain" },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), "A basic air element", "💨", true, "Air" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementId", "Name" },
                values: new object[] { new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"), "Create Mud and Rain to progress.", 2, new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"), "Nature's Recipe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"),
                column: "Icon",
                value: "💨");
        }
    }
}
