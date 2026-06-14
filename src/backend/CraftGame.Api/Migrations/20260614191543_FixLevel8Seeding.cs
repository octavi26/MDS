using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixLevel8Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("09c7a812-813f-4ae7-b7fc-e54ab070c650"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("69dc7422-e5bc-4339-9b3c-f50822f6b1d9"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("b51fc042-ed34-4b65-be9f-549a878ae000"));

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("0d1856ab-2288-4a02-a064-a1d46625cdca"), new Guid("dc92f3cb-b82c-406b-828a-04c791c300db") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("2da3ade6-2827-4254-ac44-0ed672300dcd"), new Guid("ba9c909d-3d85-4c1c-a3ab-3f200671e7b2") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("6157c5ca-3655-47a0-81b3-3019e21b3829"), new Guid("13fa9943-2d02-4f39-b9f6-e145e62d5d62") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("86c991c9-05e2-48bd-acdc-0e48ca45e8f7"), new Guid("fedcba98-7654-3210-fedc-ba9876543210") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("11cae710-b744-4b34-a016-a5be5e7be3c4") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d"), new Guid("dc92f3cb-b82c-406b-828a-04c791c300db") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), new Guid("13fa9943-2d02-4f39-b9f6-e145e62d5d62") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("c77fb0f6-34ad-4140-bf23-c98d2a2b08cc"), new Guid("11cae710-b744-4b34-a016-a5be5e7be3c4") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("d44f501d-1895-4f90-b14b-1695bac75ed0"), new Guid("ba9c909d-3d85-4c1c-a3ab-3f200671e7b2") });

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
                keyValue: new Guid("86c991c9-05e2-48bd-acdc-0e48ca45e8f7"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
