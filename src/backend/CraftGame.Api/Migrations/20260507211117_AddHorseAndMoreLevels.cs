using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddHorseAndMoreLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("a6b7c8d9-e0f1-2a3b-4c5d-6e7f8a9b0c1d"), "A majestic animal", "🐎", false, "Horse" },
                    { new Guid("f5e6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"), "The spark of existence", "🧬", false, "Life" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementId", "Name" },
                values: new object[,]
                {
                    { new Guid("01234567-89ab-cdef-0123-456789abcdef"), "Can you find the spark of Life?", 3, new Guid("f5e6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"), "Life's Mystery" },
                    { new Guid("fedcba98-7654-3210-fedc-ba9876543210"), "Bring a Horse to life!", 4, new Guid("a6b7c8d9-e0f1-2a3b-4c5d-6e7f8a9b0c1d"), "Animal Kingdom" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a6b7c8d9-e0f1-2a3b-4c5d-6e7f8a9b0c1d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f5e6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"));
        }
    }
}
