using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810840"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("44aaaa35-f8a5-452d-b10c-a1a753ec6358"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf2"));

            migrationBuilder.InsertData(
                table: "DifficultySet",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810842"), "Medium" },
                    { new Guid("44aaaa35-f8a5-452d-b10c-a1a753ec6359"), "Easy" },
                    { new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf1"), "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810842"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("44aaaa35-f8a5-452d-b10c-a1a753ec6359"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf1"));

            migrationBuilder.InsertData(
                table: "DifficultySet",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810840"), "Medium" },
                    { new Guid("44aaaa35-f8a5-452d-b10c-a1a753ec6358"), "Easy" },
                    { new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf2"), "Hard" }
                });
        }
    }
}
