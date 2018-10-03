using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Saffron.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cookbook",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookbook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 120, nullable: false),
                    Steps = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    SourceUrl = table.Column<string>(nullable: true),
                    Yield = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 60, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    CookbookId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Cookbook_CookbookId",
                        column: x => x.CookbookId,
                        principalTable: "Cookbook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookBookRecipeBind",
                columns: table => new
                {
                    CookbookId = table.Column<Guid>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookBookRecipeBind", x => new { x.CookbookId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_CookBookRecipeBind_Cookbook_CookbookId",
                        column: x => x.CookbookId,
                        principalTable: "Cookbook",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookBookRecipeBind_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookingTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeTitle = table.Column<string>(nullable: true),
                    Minutes = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    RecipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingTime_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingradient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Units = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    RecipeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingradient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingradient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookBookRecipeBind_RecipeId",
                table: "CookBookRecipeBind",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingTime_RecipeId",
                table: "CookingTime",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingradient_RecipeId",
                table: "Ingradient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_CookbookId",
                table: "Section",
                column: "CookbookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookBookRecipeBind");

            migrationBuilder.DropTable(
                name: "CookingTime");

            migrationBuilder.DropTable(
                name: "Ingradient");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Cookbook");
        }
    }
}
