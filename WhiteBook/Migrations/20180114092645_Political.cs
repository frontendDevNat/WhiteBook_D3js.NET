using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class Political : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GermanyCity_GermanyRegions_GermanyRegionId",
                table: "GermanyCity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GermanyCity",
                table: "GermanyCity");

            migrationBuilder.RenameTable(
                name: "GermanyCity",
                newName: "GermanyCities");

            migrationBuilder.RenameIndex(
                name: "IX_GermanyCity_GermanyRegionId",
                table: "GermanyCities",
                newName: "IX_GermanyCities_GermanyRegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GermanyCities",
                table: "GermanyCities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Confessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true),
                    ReligionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confessions_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartiesMovements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalPartiesMovements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RiskyLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskyLevels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confessions_ReligionId",
                table: "Confessions",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GermanyCities_GermanyRegions_GermanyRegionId",
                table: "GermanyCities",
                column: "GermanyRegionId",
                principalTable: "GermanyRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GermanyCities_GermanyRegions_GermanyRegionId",
                table: "GermanyCities");

            migrationBuilder.DropTable(
                name: "Confessions");

            migrationBuilder.DropTable(
                name: "PoliticalPartiesMovements");

            migrationBuilder.DropTable(
                name: "RiskyLevels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GermanyCities",
                table: "GermanyCities");

            migrationBuilder.RenameTable(
                name: "GermanyCities",
                newName: "GermanyCity");

            migrationBuilder.RenameIndex(
                name: "IX_GermanyCities_GermanyRegionId",
                table: "GermanyCity",
                newName: "IX_GermanyCity_GermanyRegionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GermanyCity",
                table: "GermanyCity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GermanyCity_GermanyRegions_GermanyRegionId",
                table: "GermanyCity",
                column: "GermanyRegionId",
                principalTable: "GermanyRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
