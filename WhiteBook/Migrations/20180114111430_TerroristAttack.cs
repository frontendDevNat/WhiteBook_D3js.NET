using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class TerroristAttack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RadicalOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true),
                    PoliticalPartiesMovementId = table.Column<int>(nullable: true),
                    ReligionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadicalOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadicalOrganizations_PoliticalPartiesMovements_PoliticalPartiesMovementId",
                        column: x => x.PoliticalPartiesMovementId,
                        principalTable: "PoliticalPartiesMovements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadicalOrganizations_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TerroristAttacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Descr = table.Column<string>(nullable: true),
                    GermanyCityId = table.Column<int>(nullable: true),
                    InjuredQuantity = table.Column<int>(nullable: false),
                    RadicalOrganizationId = table.Column<int>(nullable: true),
                    TerroristAttackTypeId = table.Column<int>(nullable: true),
                    VictimsQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerroristAttacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TerroristAttacks_GermanyCities_GermanyCityId",
                        column: x => x.GermanyCityId,
                        principalTable: "GermanyCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TerroristAttacks_RadicalOrganizations_RadicalOrganizationId",
                        column: x => x.RadicalOrganizationId,
                        principalTable: "RadicalOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TerroristAttacks_TerroristAttackTypes_TerroristAttackTypeId",
                        column: x => x.TerroristAttackTypeId,
                        principalTable: "TerroristAttackTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RadicalOrganizations_PoliticalPartiesMovementId",
                table: "RadicalOrganizations",
                column: "PoliticalPartiesMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_RadicalOrganizations_ReligionId",
                table: "RadicalOrganizations",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristAttacks_GermanyCityId",
                table: "TerroristAttacks",
                column: "GermanyCityId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristAttacks_RadicalOrganizationId",
                table: "TerroristAttacks",
                column: "RadicalOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TerroristAttacks_TerroristAttackTypeId",
                table: "TerroristAttacks",
                column: "TerroristAttackTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerroristAttacks");

            migrationBuilder.DropTable(
                name: "RadicalOrganizations");
        }
    }
}
