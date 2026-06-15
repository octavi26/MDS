using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftGame.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCraftingRecipeCache : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CraftingRecipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ElementAKey = table.Column<string>(type: "text", nullable: false),
                    ElementBKey = table.Column<string>(type: "text", nullable: false),
                    ElementADisplay = table.Column<string>(type: "text", nullable: false),
                    ElementBDisplay = table.Column<string>(type: "text", nullable: false),
                    ResultElementId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraftingRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CraftingRecipes_Elements_ResultElementId",
                        column: x => x.ResultElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CraftingRecipes_ElementAKey_ElementBKey",
                table: "CraftingRecipes",
                columns: new[] { "ElementAKey", "ElementBKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CraftingRecipes_ResultElementId",
                table: "CraftingRecipes",
                column: "ResultElementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CraftingRecipes");
        }
    }
}
