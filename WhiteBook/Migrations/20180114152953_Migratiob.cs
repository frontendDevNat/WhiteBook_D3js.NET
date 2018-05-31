using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class Migratiob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CyberThreats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountrySourceId = table.Column<int>(nullable: true),
                    CyberThreatTypeId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Descr = table.Column<string>(nullable: true),
                    RadicalOrganizationId = table.Column<int>(nullable: true),
                    RiskyLevelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberThreats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CyberThreats_Countries_CountrySourceId",
                        column: x => x.CountrySourceId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberThreats_CyberThreatTypes_CyberThreatTypeId",
                        column: x => x.CyberThreatTypeId,
                        principalTable: "CyberThreatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberThreats_RadicalOrganizations_RadicalOrganizationId",
                        column: x => x.RadicalOrganizationId,
                        principalTable: "RadicalOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CyberThreats_RiskyLevels_RiskyLevelId",
                        column: x => x.RiskyLevelId,
                        principalTable: "RiskyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CyberThreats_CountrySourceId",
                table: "CyberThreats",
                column: "CountrySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberThreats_CyberThreatTypeId",
                table: "CyberThreats",
                column: "CyberThreatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberThreats_RadicalOrganizationId",
                table: "CyberThreats",
                column: "RadicalOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CyberThreats_RiskyLevelId",
                table: "CyberThreats",
                column: "RiskyLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberThreats");
        }
    }
}
