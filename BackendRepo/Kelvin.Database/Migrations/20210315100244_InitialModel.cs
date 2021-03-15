using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kelvin.Database.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatesCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NoteContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNote = table.Column<int>(type: "int", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteContent_Notes",
                        column: x => x.IdNote,
                        principalTable: "notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContent = table.Column<int>(type: "int", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteFiles_NoteContent",
                        column: x => x.IdContent,
                        principalTable: "NoteContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteContent_IdNote",
                table: "NoteContent",
                column: "IdNote");

            migrationBuilder.CreateIndex(
                name: "IX_NoteFiles_IdContent",
                table: "NoteFiles",
                column: "IdContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteFiles");

            migrationBuilder.DropTable(
                name: "NoteContent");

            migrationBuilder.DropTable(
                name: "notes");
        }
    }
}
