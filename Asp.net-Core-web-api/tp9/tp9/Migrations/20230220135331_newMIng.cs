using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp9.Migrations
{
    public partial class newMIng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "bookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BookId",
                table: "bookAuthors",
                newName: "IX_bookAuthors_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookAuthors",
                table: "bookAuthors",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_bookAuthors_Authors_AuthorId",
                table: "bookAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookAuthors_Books_BookId",
                table: "bookAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookAuthors_Authors_AuthorId",
                table: "bookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_bookAuthors_Books_BookId",
                table: "bookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookAuthors",
                table: "bookAuthors");

            migrationBuilder.RenameTable(
                name: "bookAuthors",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_bookAuthors_BookId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                columns: new[] { "AuthorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Authors_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Books_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
