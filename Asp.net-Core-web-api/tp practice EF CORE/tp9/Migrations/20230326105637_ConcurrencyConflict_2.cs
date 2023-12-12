using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class ConcurrencyConflict_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concurrencyBooks",
                columns: table => new
                {
                    ConcurrencyBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concurrencyBooks", x => x.ConcurrencyBookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concurrencyBooks");
        }
    }
}
