using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Primary_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secondary_phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Birth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "commande");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
