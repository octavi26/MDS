using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlayableLevelDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("032d09be-7e8b-4b6e-b662-6488f4863215"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("62dd35c1-1f68-45e5-a886-994e2d35e12d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("78b60ed0-f0aa-4eb1-8e1e-5e2601dd1143"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("82143aec-f657-4929-bd8a-3d8d6e190f14"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("8b5ef11f-dd86-4863-a7d5-c7498cab971d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("8fb9a9ff-55eb-4273-b5c5-d9ceb1b38644"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("9269009f-a7ca-4a9f-8d23-ee783cdcccfd"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("965e9f41-3d2d-4a05-a58b-5880a1aa1749"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("ab31d349-3e07-4e95-888b-0a6291b52aeb"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b58e0aad-2bd6-40f2-8698-79a9119f8271"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c615e804-8d53-48fa-a335-a67c502bb5a3"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c86386bc-ad04-44cf-9eb2-208b4fadfd39"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("e41e62bf-5036-4a3b-9d34-8ea5b95e87fc"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f12f48ec-32d5-4abc-a01c-a362d3029d5e"));

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("08ac0228-8db1-4669-aaf2-43713c2b4848"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("2bfb6a22-65af-49e8-b90f-b495fd7a0b23"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("2bfb6a22-65af-49e8-b90f-b495fd7a0b23"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("389e82c2-0154-4670-9a6e-66c14f3da6e6"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("567ac8db-1929-47c2-8a91-73ec5d89b81b"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("567ac8db-1929-47c2-8a91-73ec5d89b81b"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("81665166-af36-413d-8657-c1e00d7fee91"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("81665166-af36-413d-8657-c1e00d7fee91"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("9306f641-61f4-4914-8110-52298f43770d"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("afb2f800-d8ff-443c-8068-6cfd4a6d33cd"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1bbd332-f39e-4c73-9a2f-955564a08a61"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c3d21c24-e7a2-4558-83b3-5e2ca8160332"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("08ac0228-8db1-4669-aaf2-43713c2b4848"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("2bfb6a22-65af-49e8-b90f-b495fd7a0b23"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("389e82c2-0154-4670-9a6e-66c14f3da6e6"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("567ac8db-1929-47c2-8a91-73ec5d89b81b"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("81665166-af36-413d-8657-c1e00d7fee91"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("9306f641-61f4-4914-8110-52298f43770d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("afb2f800-d8ff-443c-8068-6cfd4a6d33cd"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b1bbd332-f39e-4c73-9a2f-955564a08a61"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c3d21c24-e7a2-4558-83b3-5e2ca8160332"));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"),
                column: "Description",
                value: "A basic earth element");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"),
                column: "Description",
                value: "A basic water element");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"),
                column: "Description",
                value: "A basic fire element");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"),
                column: "Description",
                value: "A basic air element");

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("0d367258-b056-4a63-b15d-441e3940feaf"), "Pure power", "⚡", false, "Energy" },
                    { new Guid("1e70e58b-c328-4a04-be4f-a2c16aae14eb"), "Organic material", "🪵", false, "Wood" },
                    { new Guid("205734b2-0254-4e7f-b095-b8ac49bd5c4b"), "Human-Machine hybrid", "🦾", false, "Cyborg" },
                    { new Guid("27b7f07c-f5f8-434e-be87-2414d120759c"), "Crafted instrument", "🛠️", false, "Tool" },
                    { new Guid("306c2345-be15-4fa4-8e2f-1dfe8d792643"), "Rolling tool", "🎡", false, "Wheel" },
                    { new Guid("37cf0b28-ecd2-4fc2-b758-83f21ca0e247"), "Hard rock", "🪨", false, "Stone" },
                    { new Guid("4e963255-ddfb-447d-b0e6-0237271f8d1d"), "Vehicle", "🚗", false, "Car" },
                    { new Guid("6e27bc6a-9790-4ddb-8b2b-1d68349544dd"), "Mechanical life", "🤖", false, "Robot" },
                    { new Guid("7bc855bd-5e73-4b78-8230-eb7d9f30f2a1"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("a0f88725-69f2-462b-ace8-ac6a51e7d51b"), "Machine core", "⚙️", false, "Engine" },
                    { new Guid("a60f7fcc-619a-4242-b369-3f8be35cac4e"), "The spark of existence", "✨", false, "Life" },
                    { new Guid("cd7f6f66-d9b0-4d52-9d47-3915235a0cf8"), "Hot vapor", "💨", false, "Steam" },
                    { new Guid("d7cace2b-6a2b-4a76-8da8-78561e18ed87"), "Sentient life", "🧍", false, "Human" },
                    { new Guid("e680e741-81cd-4a3a-a7a1-8ec8671b746c"), "Biological blueprint", "🧬", false, "DNA" },
                    { new Guid("fe8356fa-a630-479a-bd4b-55b35974d9d9"), "Forged material", "⛓️", false, "Metal" }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("77777777-7777-7777-7777-777777777777") }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "The journey begins. Combine Fire and Water to create Steam.", "Steam", "Mission: First Vapor" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Earth meets Water. Find Mud.", "Mud", "Mission: Muddy Path" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Combine Fire and Mud to bake a Stone.", 2, "Stone", "Mission: Solid Base" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Extreme heat on Stone reveals Metal.", "Metal", "Mission: Metal Age" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Use Metal and Wood to craft a Tool.", "Tool", "Mission: Tools of Trade" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "A Tool and Wood create the Wheel.", 3, "Wheel", "Mission: The Wheel" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "Description", "Difficulty", "Name" },
                values: new object[] { "Steam power and Metal give birth to the Engine.", 4, "Mission: The Engine" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Assemble a Car from an Engine and Wheels.", 5, "Car", "Mission: Transportation" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Infuse Life into DNA to create a Human.", 6, "Human", "Mission: Biotechnology" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "The ultimate union. Merge Human and Robot into a Cyborg.", "Cyborg", "Mission: The Singularity" });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("0d367258-b056-4a63-b15d-441e3940feaf"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("1e70e58b-c328-4a04-be4f-a2c16aae14eb"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("1e70e58b-c328-4a04-be4f-a2c16aae14eb"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("27b7f07c-f5f8-434e-be87-2414d120759c"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("306c2345-be15-4fa4-8e2f-1dfe8d792643"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("37cf0b28-ecd2-4fc2-b758-83f21ca0e247"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("6e27bc6a-9790-4ddb-8b2b-1d68349544dd"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("7bc855bd-5e73-4b78-8230-eb7d9f30f2a1"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a0f88725-69f2-462b-ace8-ac6a51e7d51b"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("a60f7fcc-619a-4242-b369-3f8be35cac4e"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("cd7f6f66-d9b0-4d52-9d47-3915235a0cf8"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("d7cace2b-6a2b-4a76-8da8-78561e18ed87"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("e680e741-81cd-4a3a-a7a1-8ec8671b746c"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("fe8356fa-a630-479a-bd4b-55b35974d9d9"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("fe8356fa-a630-479a-bd4b-55b35974d9d9"), new Guid("77777777-7777-7777-7777-777777777777") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("205734b2-0254-4e7f-b095-b8ac49bd5c4b"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("4e963255-ddfb-447d-b0e6-0237271f8d1d"));

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("0d367258-b056-4a63-b15d-441e3940feaf"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("1e70e58b-c328-4a04-be4f-a2c16aae14eb"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("1e70e58b-c328-4a04-be4f-a2c16aae14eb"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("27b7f07c-f5f8-434e-be87-2414d120759c"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("306c2345-be15-4fa4-8e2f-1dfe8d792643"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("37cf0b28-ecd2-4fc2-b758-83f21ca0e247"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("6e27bc6a-9790-4ddb-8b2b-1d68349544dd"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("7bc855bd-5e73-4b78-8230-eb7d9f30f2a1"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a0f88725-69f2-462b-ace8-ac6a51e7d51b"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a60f7fcc-619a-4242-b369-3f8be35cac4e"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("cd7f6f66-d9b0-4d52-9d47-3915235a0cf8"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("d7cace2b-6a2b-4a76-8da8-78561e18ed87"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("e680e741-81cd-4a3a-a7a1-8ec8671b746c"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("fe8356fa-a630-479a-bd4b-55b35974d9d9"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("fe8356fa-a630-479a-bd4b-55b35974d9d9"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("0d367258-b056-4a63-b15d-441e3940feaf"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("1e70e58b-c328-4a04-be4f-a2c16aae14eb"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("27b7f07c-f5f8-434e-be87-2414d120759c"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("306c2345-be15-4fa4-8e2f-1dfe8d792643"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("37cf0b28-ecd2-4fc2-b758-83f21ca0e247"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("6e27bc6a-9790-4ddb-8b2b-1d68349544dd"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("7bc855bd-5e73-4b78-8230-eb7d9f30f2a1"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a0f88725-69f2-462b-ace8-ac6a51e7d51b"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a60f7fcc-619a-4242-b369-3f8be35cac4e"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("cd7f6f66-d9b0-4d52-9d47-3915235a0cf8"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d7cace2b-6a2b-4a76-8da8-78561e18ed87"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("e680e741-81cd-4a3a-a7a1-8ec8671b746c"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("fe8356fa-a630-479a-bd4b-55b35974d9d9"));

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"),
                column: "Description",
                value: "Solid ground");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"),
                column: "Description",
                value: "Liquid life");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"),
                column: "Description",
                value: "Burning passion");

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"),
                column: "Description",
                value: "Invisible gas");

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("032d09be-7e8b-4b6e-b662-6488f4863215"), "Steel blade", "⚔️", false, "Sword" },
                    { new Guid("08ac0228-8db1-4669-aaf2-43713c2b4848"), "Life in the machine", "🤖", false, "AI" },
                    { new Guid("2bfb6a22-65af-49e8-b90f-b495fd7a0b23"), "Abstract thought", "🧠", false, "Logic" },
                    { new Guid("389e82c2-0154-4670-9a6e-66c14f3da6e6"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("567ac8db-1929-47c2-8a91-73ec5d89b81b"), "Heavy metal", "⛓️", false, "Iron" },
                    { new Guid("62dd35c1-1f68-45e5-a886-994e2d35e12d"), "Cloudy residue", "🚬", false, "Smoke" },
                    { new Guid("78b60ed0-f0aa-4eb1-8e1e-5e2601dd1143"), "Cut wood", "🪵", false, "Plank" },
                    { new Guid("81665166-af36-413d-8657-c1e00d7fee91"), "Strong alloy", "🛡️", false, "Steel" },
                    { new Guid("82143aec-f657-4929-bd8a-3d8d6e190f14"), "Silicone brain", "🔲", false, "Chip" },
                    { new Guid("8b5ef11f-dd86-4863-a7d5-c7498cab971d"), "Giant plant", "🌳", false, "Tree" },
                    { new Guid("8fb9a9ff-55eb-4273-b5c5-d9ceb1b38644"), "Hard rock", "🪨", false, "Stone" },
                    { new Guid("9269009f-a7ca-4a9f-8d23-ee783cdcccfd"), "Mechanical life", "🤖", false, "Robot" },
                    { new Guid("9306f641-61f4-4914-8110-52298f43770d"), "Pure power", "⚡", false, "Energy" },
                    { new Guid("965e9f41-3d2d-4a05-a58b-5880a1aa1749"), "Baked mud", "🧱", false, "Brick" },
                    { new Guid("ab31d349-3e07-4e95-888b-0a6291b52aeb"), "Living being", "🐒", false, "Creature" },
                    { new Guid("afb2f800-d8ff-443c-8068-6cfd4a6d33cd"), "Organic material", "🪵", false, "Wood" },
                    { new Guid("b1bbd332-f39e-4c73-9a2f-955564a08a61"), "Potential growth", "🌱", false, "Seed" },
                    { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), "The vital spark", "✨", false, "Life" },
                    { new Guid("b58e0aad-2bd6-40f2-8698-79a9119f8271"), "Sea of trees", "🌲", false, "Forest" },
                    { new Guid("c3d21c24-e7a2-4558-83b3-5e2ca8160332"), "Vapor power", "💨", false, "Steam" },
                    { new Guid("c615e804-8d53-48fa-a335-a67c502bb5a3"), "Source of motion", "⚙️", false, "Engine" },
                    { new Guid("c86386bc-ad04-44cf-9eb2-208b4fadfd39"), "Fine particles", "🌫️", false, "Dust" },
                    { new Guid("e41e62bf-5036-4a3b-9d34-8ea5b95e87fc"), "Burnt wood", "🌑", false, "Charcoal" },
                    { new Guid("f12f48ec-32d5-4abc-a01c-a362d3029d5e"), "Green growth", "🌿", false, "Plant" }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("55555555-5555-5555-5555-555555555555") }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Start with only Fire. Find Smoke.", "Smoke", "Mission: Thermal Start" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Water meets Air. Create Steam.", "Steam", "Mission: The Mist" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Water, Earth, and Fire. Find Mud.", 1, "Mud", "Mission: Foundation" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Mud, Fire, and Air. Create Brick.", "Brick", "Mission: Alchemy" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Seed, Water, Earth, and Air. Create a Plant.", "Plant", "Mission: Botany" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Iron, Wood, and Fire. Forge Steel.", 4, "Steel", "Mission: Blacksmith" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"),
                columns: new[] { "Description", "Difficulty", "Name" },
                values: new object[] { "Steel, Steam, and Logic. Create an Engine.", 5, "Mission: Industry" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Life, Water, and Earth. Create a Creature.", 6, "Creature", "Mission: Vitality" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Energy, Logic, and Iron. Create a Chip.", 7, "Chip", "Mission: Digital" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Description", "GoalElementName", "Name" },
                values: new object[] { "Chip, Life, and Steel. Create a Robot.", "Robot", "Mission: Singularity" });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("08ac0228-8db1-4669-aaf2-43713c2b4848"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("2bfb6a22-65af-49e8-b90f-b495fd7a0b23"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("2bfb6a22-65af-49e8-b90f-b495fd7a0b23"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("389e82c2-0154-4670-9a6e-66c14f3da6e6"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("567ac8db-1929-47c2-8a91-73ec5d89b81b"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("567ac8db-1929-47c2-8a91-73ec5d89b81b"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("81665166-af36-413d-8657-c1e00d7fee91"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("81665166-af36-413d-8657-c1e00d7fee91"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("9306f641-61f4-4914-8110-52298f43770d"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("afb2f800-d8ff-443c-8068-6cfd4a6d33cd"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("b1bbd332-f39e-4c73-9a2f-955564a08a61"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("c3d21c24-e7a2-4558-83b3-5e2ca8160332"), new Guid("77777777-7777-7777-7777-777777777777") }
                });
        }
    }
}
