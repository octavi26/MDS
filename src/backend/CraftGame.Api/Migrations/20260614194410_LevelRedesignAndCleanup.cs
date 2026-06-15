using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class LevelRedesignAndCleanup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("0754c578-ba64-4223-ad30-fbbc66bfa20d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("100ca108-27ab-43af-962c-b11fcb394a8a"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("22a6cd60-3078-492f-93cd-1094c4b1ccde"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("2c9cbdb5-845b-4d25-94f8-0ae56a4073af"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("34679d83-ba1b-4d52-85c2-bd53eca97d76"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("47809f17-565e-4ed5-bc5a-2ba4b3659d4d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("4954f32e-8666-4e6b-9883-05408e18fb7a"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("587c4e21-4181-4939-8995-3c8234dac9ee"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("59520af8-9bec-4926-8b69-ffa3d7a95441"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("6c9abfdd-58dd-4d02-8753-b310e6fe4494"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("7ac00b3e-2ad5-46c7-9ed9-d919a2e9f4e8"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("7c198daf-f671-4bdb-a263-b2dc9f29a570"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("8db87892-1f42-4d00-81c9-746af9d46279"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("8ded38e8-64b0-4175-855b-247c877bc2fc"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("9a208dbd-460c-4a31-9d60-8563d8ec73c4"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a3da2fb0-4df6-4d9c-857e-2662ecc5106b"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("a60583bb-584e-48aa-b6a1-10243c5aa6e2"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c2715e07-56e8-48f9-aa7b-04da4016ab2e"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d9c6bb01-be41-4af6-9bbd-ab74527d4aa1"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("ea38bc03-983e-4761-8b91-cac510f6a276"));

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("01234567-89ab-cdef-0123-456789abcdef") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("01234567-89ab-cdef-0123-456789abcdef") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("01234567-89ab-cdef-0123-456789abcdef") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("01234567-89ab-cdef-0123-456789abcdef") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") });

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("170effd3-724e-493c-a10a-06c7733ad8b6"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("faa2522e-7259-4f51-b313-d3e23a05efba"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"));

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
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Start with only Fire. Find Smoke.", 1, "Smoke", "Mission: Thermal Start", 1 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Water meets Air. Create Steam.", 1, "Steam", "Mission: The Mist", 2 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Water, Earth, and Fire. Find Mud.", 1, "Mud", "Mission: Foundation", 3 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Mud, Fire, and Air. Create Brick.", 2, "Brick", "Mission: Alchemy", 4 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Seed, Water, Earth, and Air. Create a Plant.", 3, "Plant", "Mission: Botany", 5 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Iron, Wood, and Fire. Forge Steel.", 4, "Steel", "Mission: Blacksmith", 6 },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Steel, Steam, and Logic. Create an Engine.", 5, "Engine", "Mission: Industry", 7 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Life, Water, and Earth. Create a Creature.", 6, "Creature", "Mission: Vitality", 8 },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Energy, Logic, and Iron. Create a Chip.", 7, "Chip", "Mission: Digital", 9 },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Chip, Life, and Steel. Create a Robot.", 8, "Robot", "Mission: Singularity", 10 }
                });

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
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("afb2f800-d8ff-443c-8068-6cfd4a6d33cd"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("b1bbd332-f39e-4c73-9a2f-955564a08a61"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("b21ea236-2e7c-4936-9763-bd795aa4e5b9"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("c3d21c24-e7a2-4558-83b3-5e2ca8160332"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("55555555-5555-5555-5555-555555555555") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("22222222-2222-2222-2222-222222222222") });

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
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("44444444-4444-4444-4444-444444444444") });

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

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("0754c578-ba64-4223-ad30-fbbc66bfa20d"), "Boggy waters", "🐊", false, "Swamp" },
                    { new Guid("100ca108-27ab-43af-962c-b11fcb394a8a"), "Life in the machine", "🤖", false, "AI" },
                    { new Guid("22a6cd60-3078-492f-93cd-1094c4b1ccde"), "The spark of existence", "✨", false, "Life" },
                    { new Guid("2c9cbdb5-845b-4d25-94f8-0ae56a4073af"), "Rolling tool", "🎡", false, "Wheel" },
                    { new Guid("34679d83-ba1b-4d52-85c2-bd53eca97d76"), "Falling water", "🌧️", false, "Rain" },
                    { new Guid("47809f17-565e-4ed5-bc5a-2ba4b3659d4d"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("4954f32e-8666-4e6b-9883-05408e18fb7a"), "A place to live", "🏠", false, "House" },
                    { new Guid("587c4e21-4181-4939-8995-3c8234dac9ee"), "Living creature", "🐾", false, "Animal" },
                    { new Guid("59520af8-9bec-4926-8b69-ffa3d7a95441"), "Hot vapor", "💨", false, "Steam" },
                    { new Guid("6c9abfdd-58dd-4d02-8753-b310e6fe4494"), "Pure power", "⚡", false, "Energy" },
                    { new Guid("7ac00b3e-2ad5-46c7-9ed9-d919a2e9f4e8"), "Metal and electricity", "💻", false, "Computer" },
                    { new Guid("7c198daf-f671-4bdb-a263-b2dc9f29a570"), "Directed energy", "💡", false, "Electricity" },
                    { new Guid("8db87892-1f42-4d00-81c9-746af9d46279"), "Sticky mud", "🏺", false, "Clay" },
                    { new Guid("8ded38e8-64b0-4175-855b-247c877bc2fc"), "Forged earth", "⛓️", false, "Metal" },
                    { new Guid("9a208dbd-460c-4a31-9d60-8563d8ec73c4"), "Green life", "🌿", false, "Plant" },
                    { new Guid("a3da2fb0-4df6-4d9c-857e-2662ecc5106b"), "Fluffy vapor", "☁️", false, "Cloud" },
                    { new Guid("a60583bb-584e-48aa-b6a1-10243c5aa6e2"), "Helpful object", "🛠️", false, "Tool" },
                    { new Guid("c2715e07-56e8-48f9-aa7b-04da4016ab2e"), "Metal on wheels", "🚗", false, "Car" },
                    { new Guid("d9c6bb01-be41-4af6-9bbd-ab74527d4aa1"), "Baked clay", "🧱", false, "Brick" },
                    { new Guid("ea38bc03-983e-4761-8b91-cac510f6a276"), "Stacked bricks", "🧱", false, "Wall" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("01234567-89ab-cdef-0123-456789abcdef"), "Build a House from the ground up.", 3, "House", "Mission: Construction", 3 },
                    { new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9"), "Construct a Computer from logic and metal.", 7, "Computer", "Mission: Digital Age", 7 },
                    { new Guid("170effd3-724e-493c-a10a-06c7733ad8b6"), "Invent the Wheel to change everything.", 5, "Wheel", "Mission: Mechanics", 5 },
                    { new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b"), "Assemble a Car from metal and motion.", 6, "Car", "Mission: Transport", 6 },
                    { new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"), "Create Energy to begin the industrial age.", 1, "Energy", "Mission: The Spark", 1 },
                    { new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"), "Find the recipe for a Plant.", 2, "Plant", "Mission: Basic Life", 2 },
                    { new Guid("faa2522e-7259-4f51-b313-d3e23a05efba"), "Bring AI to life within the machine.", 8, "AI", "Mission: Singularity", 8 },
                    { new Guid("fedcba98-7654-3210-fedc-ba9876543210"), "Create an Animal from the primordial swamp.", 4, "Animal", "Mission: Evolution", 4 }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") }
                });
        }
    }
}
