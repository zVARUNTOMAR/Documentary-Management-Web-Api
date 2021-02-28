using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocumentaryManagementWebApi.DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActorAge = table.Column<string>(type: "int", nullable: true),
                    ActorGender = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ActorDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Docuemntaries",
                columns: table => new
                {
                    DocumentaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentaryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DocumentaryGenre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docuemntaries", x => x.DocumentaryId);
                    table.ForeignKey(
                        name: "FK_Docuemntaries_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docuemntaries_ActorId",
                table: "Docuemntaries",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docuemntaries");

            migrationBuilder.DropTable(
                name: "Actors");
        }
    }
}
