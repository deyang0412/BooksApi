using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksApi.HttpHost.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookKinds",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookKinds", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    Account = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_UserGuid", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    ISBN = table.Column<int>(maxLength: 13, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Author = table.Column<string>(maxLength: 30, nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: true),
                    BookKindGuid = table.Column<string>(maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Books_BookKinds_BookKindGuid",
                        column: x => x.BookKindGuid,
                        principalTable: "BookKinds",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    OrderNo = table.Column<string>(maxLength: 10, nullable: false),
                    UserGuid = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 1)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(nullable: true),
                    ETD = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserGuid",
                        column: x => x.UserGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    BookGuid = table.Column<string>(maxLength: 36, nullable: false),
                    ReplenishDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false, defaultValue: 0)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Inventories_Books_BookGuid",
                        column: x => x.BookGuid,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookOrder",
                columns: table => new
                {
                    BookGuid = table.Column<string>(nullable: false),
                    OrderGuid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOrder", x => new { x.BookGuid, x.OrderGuid });
                    table.ForeignKey(
                        name: "FK_BookOrder_Books_BookGuid",
                        column: x => x.BookGuid,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookOrder_Order_OrderGuid",
                        column: x => x.OrderGuid,
                        principalTable: "Order",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookOrder_OrderGuid",
                table: "BookOrder",
                column: "OrderGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookKindGuid",
                table: "Books",
                column: "BookKindGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BookGuid",
                table: "Inventories",
                column: "BookGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserGuid",
                table: "Order",
                column: "UserGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookOrder");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BookKinds");
        }
    }
}
