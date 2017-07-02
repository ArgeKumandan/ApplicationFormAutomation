using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApplicationFormAutomation.WebUI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormSubmits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormSubmits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataKey = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FormElementType = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false),
                    FreeTextElemenType = table.Column<int>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    Mask = table.Column<string>(nullable: true),
                    OrderValue = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UseMaskForFreeText = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormElements_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnswerText = table.Column<string>(nullable: true),
                    FormElementId = table.Column<int>(nullable: false),
                    FormSubmitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormAnswer_FormElements_FormElementId",
                        column: x => x.FormElementId,
                        principalTable: "FormElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormAnswer_FormSubmits_FormSubmitId",
                        column: x => x.FormSubmitId,
                        principalTable: "FormSubmits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormElementOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormElementId = table.Column<int>(nullable: false),
                    OrderValue = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormElementOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormElementOption_FormElements_FormElementId",
                        column: x => x.FormElementId,
                        principalTable: "FormElements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormAnswerOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormAnswerId = table.Column<int>(nullable: true),
                    FormElementOptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAnswerOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormAnswerOption_FormAnswer_FormAnswerId",
                        column: x => x.FormAnswerId,
                        principalTable: "FormAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormAnswerOption_FormElementOption_FormElementOptionId",
                        column: x => x.FormElementOptionId,
                        principalTable: "FormElementOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswer_FormElementId",
                table: "FormAnswer",
                column: "FormElementId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswer_FormSubmitId",
                table: "FormAnswer",
                column: "FormSubmitId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswerOption_FormAnswerId",
                table: "FormAnswerOption",
                column: "FormAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAnswerOption_FormElementOptionId",
                table: "FormAnswerOption",
                column: "FormElementOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormElements_FormId",
                table: "FormElements",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_FormElementOption_FormElementId",
                table: "FormElementOption",
                column: "FormElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormAnswerOption");

            migrationBuilder.DropTable(
                name: "FormAnswer");

            migrationBuilder.DropTable(
                name: "FormElementOption");

            migrationBuilder.DropTable(
                name: "FormSubmits");

            migrationBuilder.DropTable(
                name: "FormElements");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
