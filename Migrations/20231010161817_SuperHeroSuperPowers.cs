using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace superhero.Migrations
{
    /// <inheritdoc />
    public partial class SuperHeroSuperPowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_SuperHeroes_SuperHeroId",
                table: "SuperPowers");

            migrationBuilder.DropIndex(
                name: "IX_SuperPowers_SuperHeroId",
                table: "SuperPowers");

            migrationBuilder.DropColumn(
                name: "SuperHeroId",
                table: "SuperPowers");

            migrationBuilder.CreateTable(
                name: "SuperHeroSuperPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperHeroId = table.Column<int>(type: "int", nullable: false),
                    SuperPowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperHeroSuperPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperHeroSuperPowers_SuperHeroes_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperHeroSuperPowers_SuperPowers_SuperPowerId",
                        column: x => x.SuperPowerId,
                        principalTable: "SuperPowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroSuperPowers_SuperHeroId",
                table: "SuperHeroSuperPowers",
                column: "SuperHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroSuperPowers_SuperPowerId",
                table: "SuperHeroSuperPowers",
                column: "SuperPowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuperHeroSuperPowers");

            migrationBuilder.AddColumn<int>(
                name: "SuperHeroId",
                table: "SuperPowers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_SuperHeroId",
                table: "SuperPowers",
                column: "SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPowers_SuperHeroes_SuperHeroId",
                table: "SuperPowers",
                column: "SuperHeroId",
                principalTable: "SuperHeroes",
                principalColumn: "Id");
        }
    }
}
