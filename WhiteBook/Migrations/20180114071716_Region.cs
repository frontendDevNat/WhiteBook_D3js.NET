using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class Region : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CyberThreatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CyberThreatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GermanyRegions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GermanyRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MigrationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MigrationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerroristAttackTyps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerroristAttackTyps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GermanyCity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descr = table.Column<string>(nullable: true),
                    GermanyRegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GermanyCity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GermanyCity_GermanyRegions_GermanyRegionId",
                        column: x => x.GermanyRegionId,
                        principalTable: "GermanyRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GermanyCity_GermanyRegionId",
                table: "GermanyCity",
                column: "GermanyRegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CyberThreatTypes");

            migrationBuilder.DropTable(
                name: "GermanyCity");

            migrationBuilder.DropTable(
                name: "MigrationTypes");

            migrationBuilder.DropTable(
                name: "TerroristAttackTyps");

            migrationBuilder.DropTable(
                name: "GermanyRegions");
        }
    }
}
