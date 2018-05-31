using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class Danger1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Years",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DangerYears",
                columns: table => new
                {
                    DangerId = table.Column<int>(nullable: false),
                    YearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerYears", x => new { x.DangerId, x.YearId });
                    table.ForeignKey(
                        name: "FK_DangerYears_Dangers_DangerId",
                        column: x => x.DangerId,
                        principalTable: "Dangers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangerYears_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangerYears_YearId",
                table: "DangerYears",
                column: "YearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangerYears");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Years");
        }
    }
}
