using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class MigrationFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MigrationFlow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    ConfessionId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTill = table.Column<DateTime>(nullable: false),
                    Descr = table.Column<string>(nullable: true),
                    GermanyCityId = table.Column<int>(nullable: true),
                    MigrationTypeId = table.Column<int>(nullable: true),
                    RiskyLevelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationFlow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MigrationFlow_Confessions_ConfessionId",
                        column: x => x.ConfessionId,
                        principalTable: "Confessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigrationFlow_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigrationFlow_GermanyCities_GermanyCityId",
                        column: x => x.GermanyCityId,
                        principalTable: "GermanyCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigrationFlow_MigrationTypes_MigrationTypeId",
                        column: x => x.MigrationTypeId,
                        principalTable: "MigrationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MigrationFlow_RiskyLevels_RiskyLevelId",
                        column: x => x.RiskyLevelId,
                        principalTable: "RiskyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MigrationFlow_ConfessionId",
                table: "MigrationFlow",
                column: "ConfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationFlow_CountryId",
                table: "MigrationFlow",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationFlow_GermanyCityId",
                table: "MigrationFlow",
                column: "GermanyCityId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationFlow_MigrationTypeId",
                table: "MigrationFlow",
                column: "MigrationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MigrationFlow_RiskyLevelId",
                table: "MigrationFlow",
                column: "RiskyLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MigrationFlow");
        }
    }
}
