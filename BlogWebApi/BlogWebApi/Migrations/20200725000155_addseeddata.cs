using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApi.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(6614), new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(6810) });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Body", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[] { new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"), "Something interesting.", new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(8170), "Description about this title.", "Some random title", new DateTime(2020, 7, 25, 2, 1, 54, 28, DateTimeKind.Local).AddTicks(8180) });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "BlogPostId", "TagName" },
                values: new object[] { new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"), new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"), "Android" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "BlogPostId", "TagName" },
                values: new object[] { new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"), new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"), "IOS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"));

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("95c69371-b924-6fe3-7c38-98b7dd200bc1"));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 7, 25, 1, 55, 38, 686, DateTimeKind.Local).AddTicks(9661), new DateTime(2020, 7, 25, 1, 55, 38, 686, DateTimeKind.Local).AddTicks(9792) });
        }
    }
}
