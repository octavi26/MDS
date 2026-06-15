using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelProgression : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Levels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "GameSessions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "LevelStartingElement",
                columns: table => new
                {
                    ElementId = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelStartingElement", x => new { x.ElementId, x.LevelId });
                    table.ForeignKey(
                        name: "FK_LevelStartingElement_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelStartingElement_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("09c7a812-813f-4ae7-b7fc-e54ab070c650"), "Pure power", "⚡", false, "Energy" },
                    { new Guid("0d1856ab-2288-4a02-a064-a1d46625cdca"), "The spark of existence", "✨", false, "Life" },
                    { new Guid("2da3ade6-2827-4254-ac44-0ed672300dcd"), "Green life", "🌿", false, "Plant" },
                    { new Guid("6157c5ca-3655-47a0-81b3-3019e21b3829"), "A fluffy cloud", "☁️", false, "Cloud" },
                    { new Guid("69dc7422-e5bc-4339-9b3c-f50822f6b1d9"), "Boggy waters", "🐊", false, "Swamp" },
                    { new Guid("86c991c9-05e2-48bd-acdc-0e48ca45e8f7"), "Hot vapor", "💨", false, "Steam" },
                    { new Guid("b51fc042-ed34-4b65-be9f-549a878ae000"), "A living creature", "🐾", false, "Animal" },
                    { new Guid("c77fb0f6-34ad-4140-bf23-c98d2a2b08cc"), "Falling water", "🌧️", false, "Rain" },
                    { new Guid("d44f501d-1895-4f90-b14b-1695bac75ed0"), "Wet earth", "💩", false, "Mud" }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[] { "Mix Water and Earth to find Mud.", 1, "Mud", "Mission: Nature's Foundation", 3 });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"),
                columns: new[] { "Description", "GoalElementName", "Name", "Order" },
                values: new object[] { "Combine Fire and Air to create Energy!", "Energy", "Mission: The Spark", 1 });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[] { "Create Steam from Fire and Water.", 1, "Steam", "Mission: First Vapor", 2 });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[] { "Combine Air and Steam to reach the Clouds.", 2, "Cloud", "Mission: Skyward", 4 });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("11cae710-b744-4b34-a016-a5be5e7be3c4"), "Earth and Rain bring Plants.", 3, "Plant", "Mission: Growth", 6 },
                    { new Guid("13fa9943-2d02-4f39-b9f6-e145e62d5d62"), "Find Rain from Water and Clouds.", 2, "Rain", "Mission: Rain Dance", 5 },
                    { new Guid("ba9c909d-3d85-4c1c-a3ab-3f200671e7b2"), "Can you find Life in the Swamp?", 4, "Life", "Mission: Life's Mystery", 7 },
                    { new Guid("dc92f3cb-b82c-406b-828a-04c791c300db"), "An Animal from Life and Earth.", 5, "Animal", "Mission: The Beast", 8 }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("0d1856ab-2288-4a02-a064-a1d46625cdca"), new Guid("dc92f3cb-b82c-406b-828a-04c791c300db") },
                    { new Guid("2da3ade6-2827-4254-ac44-0ed672300dcd"), new Guid("ba9c909d-3d85-4c1c-a3ab-3f200671e7b2") },
                    { new Guid("6157c5ca-3655-47a0-81b3-3019e21b3829"), new Guid("13fa9943-2d02-4f39-b9f6-e145e62d5d62") },
                    { new Guid("86c991c9-05e2-48bd-acdc-0e48ca45e8f7"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("11cae710-b744-4b34-a016-a5be5e7be3c4") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("dc92f3cb-b82c-406b-828a-04c791c300db") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("13fa9943-2d02-4f39-b9f6-e145e62d5d62") },
                    { new Guid("c77fb0f6-34ad-4140-bf23-c98d2a2b08cc"), new Guid("11cae710-b744-4b34-a016-a5be5e7be3c4") },
                    { new Guid("d44f501d-1895-4f90-b14b-1695bac75ed0"), new Guid("ba9c909d-3d85-4c1c-a3ab-3f200671e7b2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LevelStartingElement_LevelId",
                table: "LevelStartingElement",
                column: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelStartingElement");

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("09c7a812-813f-4ae7-b7fc-e54ab070c650"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("0d1856ab-2288-4a02-a064-a1d46625cdca"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("2da3ade6-2827-4254-ac44-0ed672300dcd"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("6157c5ca-3655-47a0-81b3-3019e21b3829"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("69dc7422-e5bc-4339-9b3c-f50822f6b1d9"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("86c991c9-05e2-48bd-acdc-0e48ca45e8f7"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b51fc042-ed34-4b65-be9f-549a878ae000"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c77fb0f6-34ad-4140-bf23-c98d2a2b08cc"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d44f501d-1895-4f90-b14b-1695bac75ed0"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("11cae710-b744-4b34-a016-a5be5e7be3c4"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("13fa9943-2d02-4f39-b9f6-e145e62d5d62"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("ba9c909d-3d85-4c1c-a3ab-3f200671e7b2"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("dc92f3cb-b82c-406b-828a-04c791c300db"));

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "GameSessions");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Can you find the spark of Life?", 3, "Life", "Life's Mystery" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Combine elements to create Steam!", "Steam", "The First Step" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Create Mud and Rain to progress.", 2, "Rain", "Nature's Recipe" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Bring a Horse to life!", 4, "Horse", "Animal Kingdom" });
        }
    }
}
