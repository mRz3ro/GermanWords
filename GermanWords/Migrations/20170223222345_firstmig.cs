using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GermanWords.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Example = table.Column<string>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    PtDescription = table.Column<string>(nullable: true),
                    WordType = table.Column<int>(nullable: false),
                    ArticleType = table.Column<int>(nullable: true),
                    Genre = table.Column<int>(nullable: true),
                    ArticleId = table.Column<long>(nullable: true),
                    ChildName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    Parental = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Words_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherForms",
                columns: table => new
                {
                    NameId = table.Column<long>(nullable: false),
                    OtherFormId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherForms", x => new { x.NameId, x.OtherFormId });
                    table.ForeignKey(
                        name: "FK_OtherForms_Words_NameId",
                        column: x => x.NameId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherForms_Words_OtherFormId",
                        column: x => x.OtherFormId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OtherForms_OtherFormId",
                table: "OtherForms",
                column: "OtherFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_ArticleId",
                table: "Words",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherForms");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
