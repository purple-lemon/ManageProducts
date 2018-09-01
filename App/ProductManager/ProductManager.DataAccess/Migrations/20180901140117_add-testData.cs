using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManager.DataAccess.Migrations
{
    public partial class addtestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Created", "LastUpdated", "Name", "PhotoUrl", "Price" },
                values: new object[] { 1, "6e2fd4ce-9718-453a-b621-538ee8408fc8", new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), "Cheese", null, 20.5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Created", "LastUpdated", "Name", "PhotoUrl", "Price" },
                values: new object[] { 2, "dc385665-f436-4b2c-8afa-d940c9bca915", new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), "Chicken", null, 110.5m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "Created", "LastUpdated", "Name", "PhotoUrl", "Price" },
                values: new object[] { 3, "d27b7b76-eeaa-4757-a0d9-43efc6250a6f", new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), "Apples", null, 25.5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
