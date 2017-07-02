using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationFormAutomation.WebUI.Migrations
{
    public partial class FormElements_TextAreaRowCount_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextAreaRowCount",
                table: "FormElements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextAreaRowCount",
                table: "FormElements");
        }
    }
}
