using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopLand.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RequestPayMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f3fe6b7-2da5-47f5-9d61-c141d58a6061"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f27bf58c-e416-4604-9784-d4660e919ce0"));

            migrationBuilder.CreateTable(
                name: "requestPays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false),
                    IsPay = table.Column<bool>(type: "boolean", nullable: false),
                    PayDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Authority = table.Column<string>(type: "text", nullable: true),
                    RefId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestPays", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b463ed1-b124-4dcf-b455-e4773889dcf8"), "Admin" },
                    { new Guid("ccbde7e0-703e-44f0-a1f3-5fc6c8ff6051"), "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requestPays");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0b463ed1-b124-4dcf-b455-e4773889dcf8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ccbde7e0-703e-44f0-a1f3-5fc6c8ff6051"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3f3fe6b7-2da5-47f5-9d61-c141d58a6061"), "Admin" },
                    { new Guid("f27bf58c-e416-4604-9784-d4660e919ce0"), "Customer" }
                });
        }
    }
}
