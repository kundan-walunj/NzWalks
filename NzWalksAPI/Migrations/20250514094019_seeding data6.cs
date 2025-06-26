using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810842"),
                column: "Name",
                value: "Medium ");

            migrationBuilder.UpdateData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("44aaaa35-f8a5-452d-b10c-a1a753ec6359"),
                column: "Name",
                value: "Easy ");

            migrationBuilder.UpdateData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf1"),
                column: "Name",
                value: "Hard ");

            migrationBuilder.UpdateData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("a5d43070-2af0-4f07-8622-8d6c69f3f4e0"),
                column: "Name",
                value: "Bay Of Plent");

            migrationBuilder.UpdateData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("c47b7142-3f9f-4bbd-80c2-8c29c4934729"),
                column: "Name",
                value: "Aucklan");

            migrationBuilder.UpdateData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("f689fd5b-1bb4-4319-bd71-26f4a42cb057"),
                column: "Name",
                value: "Northlan");

            migrationBuilder.InsertData(
                table: "RegionSet",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("4eb24ed8-4dbd-43ad-9cf4-12d0ec4e70a3"), "STL", "Southland", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("4eb24ed8-4dbd-43ad-9cf4-12d0ec4e70a3"));

            migrationBuilder.UpdateData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810842"),
                column: "Name",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("44aaaa35-f8a5-452d-b10c-a1a753ec6359"),
                column: "Name",
                value: "Easy");

            migrationBuilder.UpdateData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf1"),
                column: "Name",
                value: "Hard");

            migrationBuilder.UpdateData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("a5d43070-2af0-4f07-8622-8d6c69f3f4e0"),
                column: "Name",
                value: "Bay Of Plenty");

            migrationBuilder.UpdateData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("c47b7142-3f9f-4bbd-80c2-8c29c4934729"),
                column: "Name",
                value: "Auckland");

            migrationBuilder.UpdateData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("f689fd5b-1bb4-4319-bd71-26f4a42cb057"),
                column: "Name",
                value: "Northland");
        }
    }
}
