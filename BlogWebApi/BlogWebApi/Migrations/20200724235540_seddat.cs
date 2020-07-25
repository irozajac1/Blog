using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApi.Migrations
{
    public partial class seddat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Body", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[] { new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"), "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 7, 25, 1, 55, 38, 686, DateTimeKind.Local).AddTicks(9661), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "Augmented Reality iOS Application", new DateTime(2020, 7, 25, 1, 55, 38, 686, DateTimeKind.Local).AddTicks(9792) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: new Guid("8286d046-9740-a3e4-95cf-ff46699c73c4"));
        }
    }
}
