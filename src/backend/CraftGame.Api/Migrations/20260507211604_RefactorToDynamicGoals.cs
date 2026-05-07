using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorToDynamicGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Levels_Elements_GoalElementId",
                table: "Levels");

            migrationBuilder.DropIndex(
                name: "IX_Levels_GoalElementId",
                table: "Levels");

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a6b7c8d9-e0f1-2a3b-4c5d-6e7f8a9b0c1d"));

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
                keyValue: new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f5e6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"));

            migrationBuilder.DropColumn(
                name: "GoalElementId",
                table: "Levels");

            migrationBuilder.AddColumn<string>(
                name: "GoalElementName",
                table: "Levels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                column: "GoalElementName",
                value: "Life");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"),
                column: "GoalElementName",
                value: "Steam");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"),
                column: "GoalElementName",
                value: "Rain");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"),
                column: "GoalElementName",
                value: "Horse");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalElementName",
                table: "Levels");

            migrationBuilder.AddColumn<Guid>(
                name: "GoalElementId",
                table: "Levels",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("a6b7c8d9-e0f1-2a3b-4c5d-6e7f8a9b0c1d"), "A majestic animal", "🐎", false, "Horse" },
                    { new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("c3d4e5f6-a7b8-9c0d-1e2f-3a4b5c6d7e8f"), "Fine particles", "🌫️", false, "Dust" },
                    { new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"), "A hot steam element", "♨️", false, "Steam" },
                    { new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"), "Water falling from the sky", "🌧️", false, "Rain" },
                    { new Guid("f5e6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"), "The spark of existence", "🧬", false, "Life" }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                column: "GoalElementId",
                value: new Guid("f5e6a7b8-c9d0-1e2f-3a4b-5c6d7e8f9a0b"));

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"),
                column: "GoalElementId",
                value: new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"));

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"),
                column: "GoalElementId",
                value: new Guid("d4e5f6a7-b8c9-0d1e-2f3a-4b5c6d7e8f9a"));

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"),
                column: "GoalElementId",
                value: new Guid("a6b7c8d9-e0f1-2a3b-4c5d-6e7f8a9b0c1d"));

            migrationBuilder.CreateIndex(
                name: "IX_Levels_GoalElementId",
                table: "Levels",
                column: "GoalElementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Levels_Elements_GoalElementId",
                table: "Levels",
                column: "GoalElementId",
                principalTable: "Elements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
