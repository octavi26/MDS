using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSessionCompletionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValues: new object[] { new Guid("a60f7fcc-619a-4242-b369-3f8be35cac4e"), new Guid("99999999-9999-9999-9999-999999999999") });

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "GameSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Description", "Icon", "IsStartingElement", "Name" },
                values: new object[,]
                {
                    { new Guid("15d21606-737a-4f8e-81fa-08a439cf407f"), "Wet earth", "💩", false, "Mud" },
                    { new Guid("1751b084-2cc8-4abc-9c46-5f915e6e2b79"), "Hard rock", "🪨", false, "Stone" },
                    { new Guid("24af5e8c-186c-4886-93f4-53171f54045e"), "Hot vapor", "💨", false, "Steam" },
                    { new Guid("2811f056-bcda-4dee-aa12-f49235277733"), "Sentient life", "🧍", false, "Human" },
                    { new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e"), "Organic material", "🪵", false, "Wood" },
                    { new Guid("40e582ff-0317-43a5-83b0-fdc83e2343db"), "The spark of existence", "✨", false, "Life" },
                    { new Guid("4eda4bc0-da00-43e1-83ed-293a35180476"), "Vehicle", "🚗", false, "Car" },
                    { new Guid("52be66d6-c58a-4379-a53d-d75dfcdaee19"), "Pure power", "⚡", false, "Energy" },
                    { new Guid("5cdaaf70-a9bb-40d9-aff7-6548cd13867c"), "Crafted instrument", "🛠️", false, "Tool" },
                    { new Guid("7c599ff1-2874-46c8-964d-8a2215368c11"), "Machine core", "⚙️", false, "Engine" },
                    { new Guid("9e2178d5-f5a1-40ef-9341-0b119bb341ec"), "Rolling tool", "🎡", false, "Wheel" },
                    { new Guid("c8cb07b9-90c1-48fc-9252-b0334175091b"), "Human-Machine hybrid", "🦾", false, "Cyborg" },
                    { new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1"), "Forged material", "⛓️", false, "Metal" },
                    { new Guid("ed102632-5c7b-4246-a60f-65049935ac77"), "Mechanical life", "🤖", false, "Robot" },
                    { new Guid("fb802ed3-aaf1-4f35-a98c-2b0b3ca998ff"), "Biological blueprint", "🧬", false, "DNA" }
                });

            migrationBuilder.InsertData(
                table: "LevelStartingElement",
                columns: new[] { "ElementId", "LevelId" },
                values: new object[,]
                {
                    { new Guid("15d21606-737a-4f8e-81fa-08a439cf407f"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("1751b084-2cc8-4abc-9c46-5f915e6e2b79"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("24af5e8c-186c-4886-93f4-53171f54045e"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("2811f056-bcda-4dee-aa12-f49235277733"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("40e582ff-0317-43a5-83b0-fdc83e2343db"), new Guid("99999999-9999-9999-9999-999999999999") },
                    { new Guid("52be66d6-c58a-4379-a53d-d75dfcdaee19"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("5cdaaf70-a9bb-40d9-aff7-6548cd13867c"), new Guid("66666666-6666-6666-6666-666666666666") },
                    { new Guid("7c599ff1-2874-46c8-964d-8a2215368c11"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("9e2178d5-f5a1-40ef-9341-0b119bb341ec"), new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1"), new Guid("55555555-5555-5555-5555-555555555555") },
                    { new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1"), new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("ed102632-5c7b-4246-a60f-65049935ac77"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") },
                    { new Guid("fb802ed3-aaf1-4f35-a98c-2b0b3ca998ff"), new Guid("99999999-9999-9999-9999-999999999999") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("4eda4bc0-da00-43e1-83ed-293a35180476"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("c8cb07b9-90c1-48fc-9252-b0334175091b"));

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("15d21606-737a-4f8e-81fa-08a439cf407f"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("1751b084-2cc8-4abc-9c46-5f915e6e2b79"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("24af5e8c-186c-4886-93f4-53171f54045e"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("2811f056-bcda-4dee-aa12-f49235277733"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("40e582ff-0317-43a5-83b0-fdc83e2343db"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("52be66d6-c58a-4379-a53d-d75dfcdaee19"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("5cdaaf70-a9bb-40d9-aff7-6548cd13867c"), new Guid("66666666-6666-6666-6666-666666666666") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("7c599ff1-2874-46c8-964d-8a2215368c11"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("9e2178d5-f5a1-40ef-9341-0b119bb341ec"), new Guid("88888888-8888-8888-8888-888888888888") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1"), new Guid("77777777-7777-7777-7777-777777777777") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("ed102632-5c7b-4246-a60f-65049935ac77"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.DeleteData(
                table: "LevelStartingElement",
                keyColumns: new[] { "ElementId", "LevelId" },
                keyValues: new object[] { new Guid("fb802ed3-aaf1-4f35-a98c-2b0b3ca998ff"), new Guid("99999999-9999-9999-9999-999999999999") });

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("15d21606-737a-4f8e-81fa-08a439cf407f"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("1751b084-2cc8-4abc-9c46-5f915e6e2b79"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("24af5e8c-186c-4886-93f4-53171f54045e"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("2811f056-bcda-4dee-aa12-f49235277733"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("40e582ff-0317-43a5-83b0-fdc83e2343db"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("52be66d6-c58a-4379-a53d-d75dfcdaee19"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("5cdaaf70-a9bb-40d9-aff7-6548cd13867c"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("7c599ff1-2874-46c8-964d-8a2215368c11"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("9e2178d5-f5a1-40ef-9341-0b119bb341ec"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("ed102632-5c7b-4246-a60f-65049935ac77"));

            migrationBuilder.DeleteData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("fb802ed3-aaf1-4f35-a98c-2b0b3ca998ff"));

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "GameSessions");

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
    }
}
