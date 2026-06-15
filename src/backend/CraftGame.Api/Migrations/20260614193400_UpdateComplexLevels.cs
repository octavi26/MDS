using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateComplexLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("0044623d-e985-4042-8116-af51f1dd39a7"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("ec7f41bf-a7b4-42ef-85b6-d8a295138791"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("f8bd532a-fa1a-46a8-b549-d9eaa282a7d6"));

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("1add35c4-7603-4924-aa09-0b65c4c82555"), new Guid("7fd1ece6-572a-4ae1-82cb-4dc6396a74de") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("36e94f4b-e923-4887-8b0f-6b09a63efc57"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("6703fd27-5332-4518-9e64-74f8f7174a08"), new Guid("7fd1ece6-572a-4ae1-82cb-4dc6396a74de") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("8308ee99-5d9f-4e0f-9c71-2185d93b8fbd"), new Guid("cd2c967b-96a5-4fe6-97ba-6077d8d05f41") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("cd2c967b-96a5-4fe6-97ba-6077d8d05f41") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("f966040f-8688-4ff8-9510-ae4cc84e31c5") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("9d352884-4702-4e8b-8a53-c9a1e9047c79") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c17d4853-9a58-4c55-b9ae-0670b9518c8d"), new Guid("9d352884-4702-4e8b-8a53-c9a1e9047c79") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("d2eef58d-5435-490f-8eb4-222d9258f875"), new Guid("f966040f-8688-4ff8-9510-ae4cc84e31c5") });

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("1add35c4-7603-4924-aa09-0b65c4c82555"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("36e94f4b-e923-4887-8b0f-6b09a63efc57"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("6703fd27-5332-4518-9e64-74f8f7174a08"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("8308ee99-5d9f-4e0f-9c71-2185d93b8fbd"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c17d4853-9a58-4c55-b9ae-0670b9518c8d"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("d2eef58d-5435-490f-8eb4-222d9258f875"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("7fd1ece6-572a-4ae1-82cb-4dc6396a74de"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("9d352884-4702-4e8b-8a53-c9a1e9047c79"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("cd2c967b-96a5-4fe6-97ba-6077d8d05f41"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f966040f-8688-4ff8-9510-ae4cc84e31c5"));

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
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("01234567-89ab-cdef-0123-456789abcdef") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Build a House from the ground up.", 3, "House", "Mission: Construction" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"),
                column: "Description",
                value: "Create Energy to begin the industrial age.");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Find the recipe for a Plant.", 2, "Plant", "Mission: Basic Life" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Create an Animal from the primordial swamp.", 4, "Animal", "Mission: Evolution" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9"), "Construct a Computer from logic and metal.", 7, "Computer", "Mission: Digital Age", 7 },
                    { new Guid("170effd3-724e-493c-a10a-06c7733ad8b6"), "Invent the Wheel to change everything.", 5, "Wheel", "Mission: Mechanics", 5 },
                    { new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b"), "Assemble a Car from metal and motion.", 6, "Car", "Mission: Transport", 6 },
                    { new Guid("faa2522e-7259-4f51-b313-d3e23a05efba"), "Bring AI to life within the machine.", 8, "AI", "Mission: Singularity", 8 }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("0f7a44b9-e5d1-43ee-8ce7-5b4d22074ef9") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("170effd3-724e-493c-a10a-06c7733ad8b6") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("3bdaf10f-3b91-48f6-9a78-281ebc0b606b") },
                    { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c"), new Guid("faa2522e-7259-4f51-b313-d3e23a05efba") });

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
                keyValue: new Guid("faa2522e-7259-4f51-b313-d3e23a05efba"));

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
                    { new Guid("0044623d-e985-4042-8116-af51f1dd39a7"), "Pure power", "⚡", false, "Energy" },
                    { new Guid("1add35c4-7603-4924-aa09-0b65c4c82555"), "Green life", "🌿", false, "Plant" },
                    { new Guid("36e94f4b-e923-4887-8b0f-6b09a63efc57"), "Hot vapor", "💨", false, "Steam" },
                    { new Guid("6703fd27-5332-4518-9e64-74f8f7174a08"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("8308ee99-5d9f-4e0f-9c71-2185d93b8fbd"), "Falling water", "🌧️", false, "Rain" },
                    { new Guid("c17d4853-9a58-4c55-b9ae-0670b9518c8d"), "A fluffy cloud", "☁️", false, "Cloud" },
                    { new Guid("d2eef58d-5435-490f-8eb4-222d9258f875"), "The spark of existence", "✨", false, "Life" },
                    { new Guid("ec7f41bf-a7b4-42ef-85b6-d8a295138791"), "A living creature", "🐾", false, "Animal" },
                    { new Guid("f8bd532a-fa1a-46a8-b549-d9eaa282a7d6"), "Boggy waters", "🐊", false, "Swamp" }
                });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("01234567-89ab-cdef-0123-456789abcdef"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Mix Water and Earth to find Mud.", 1, "Mud", "Mission: Nature's Foundation" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"),
                column: "Description",
                value: "Combine Fire and Air to create Energy!");

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Create Steam from Fire and Water.", 1, "Steam", "Mission: First Vapor" });

            migrationBuilder.UpdateData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("fedcba98-7654-3210-fedc-ba9876543210"),
                columns: new[] { "Description", "Difficulty", "GoalElementName", "Name" },
                values: new object[] { "Combine Air and Steam to reach the Clouds.", 2, "Cloud", "Mission: Skyward" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Description", "Difficulty", "GoalElementName", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("7fd1ece6-572a-4ae1-82cb-4dc6396a74de"), "Can you find Life in the Swamp?", 4, "Life", "Mission: Life's Mystery", 7 },
                    { new Guid("9d352884-4702-4e8b-8a53-c9a1e9047c79"), "Find Rain from Water and Clouds.", 2, "Rain", "Mission: Rain Dance", 5 },
                    { new Guid("cd2c967b-96a5-4fe6-97ba-6077d8d05f41"), "Earth and Rain bring Plants.", 3, "Plant", "Mission: Growth", 6 },
                    { new Guid("f966040f-8688-4ff8-9510-ae4cc84e31c5"), "An Animal from Life and Earth.", 5, "Animal", "Mission: The Beast", 8 }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("1add35c4-7603-4924-aa09-0b65c4c82555"), new Guid("7fd1ece6-572a-4ae1-82cb-4dc6396a74de") },
                    { new Guid("36e94f4b-e923-4887-8b0f-6b09a63efc57"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") },
                    { new Guid("6703fd27-5332-4518-9e64-74f8f7174a08"), new Guid("7fd1ece6-572a-4ae1-82cb-4dc6396a74de") },
                    { new Guid("8308ee99-5d9f-4e0f-9c71-2185d93b8fbd"), new Guid("cd2c967b-96a5-4fe6-97ba-6077d8d05f41") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("cd2c967b-96a5-4fe6-97ba-6077d8d05f41") },
                    { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("f966040f-8688-4ff8-9510-ae4cc84e31c5") },
                    { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("9d352884-4702-4e8b-8a53-c9a1e9047c79") },
                    { new Guid("c17d4853-9a58-4c55-b9ae-0670b9518c8d"), new Guid("9d352884-4702-4e8b-8a53-c9a1e9047c79") },
                    { new Guid("d2eef58d-5435-490f-8eb4-222d9258f875"), new Guid("f966040f-8688-4ff8-9510-ae4cc84e31c5") }
                });
        }
    }
}
