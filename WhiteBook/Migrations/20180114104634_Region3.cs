using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBook.Migrations
{
    public partial class Region3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TerroristAttackTyps",
                table: "TerroristAttackTyps");

            migrationBuilder.RenameTable(
                name: "TerroristAttackTyps",
                newName: "TerroristAttackTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TerroristAttackTypes",
                table: "TerroristAttackTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TerroristAttackTypes",
                table: "TerroristAttackTypes");

            migrationBuilder.RenameTable(
                name: "TerroristAttackTypes",
                newName: "TerroristAttackTyps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TerroristAttackTyps",
                table: "TerroristAttackTyps",
                column: "Id");
        }
    }
}
