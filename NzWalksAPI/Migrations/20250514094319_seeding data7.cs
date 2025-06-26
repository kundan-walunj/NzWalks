using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810842"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf1"));

            migrationBuilder.DeleteData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("c47b7142-3f9f-4bbd-80c2-8c29c4934729"));

            migrationBuilder.InsertData(
                table: "DifficultySet",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b91e7a1-6ac6-4b5f-801f-cbfb4351e43b"), "Medium " },
                    { new Guid("896a2fc8-5b65-4b2a-9468-5643993e148a"), "Hard " }
                });

            migrationBuilder.InsertData(
                table: "RegionSet",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("01f5d410-6cdb-49f4-959e-44a18c387b51"), "AKL", "Aucklan", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("3b91e7a1-6ac6-4b5f-801f-cbfb4351e43b"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("896a2fc8-5b65-4b2a-9468-5643993e148a"));

            migrationBuilder.DeleteData(
                table: "RegionSet",
                keyColumn: "Id",
                keyValue: new Guid("01f5d410-6cdb-49f4-959e-44a18c387b51"));

            migrationBuilder.InsertData(
                table: "DifficultySet",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0f3e1105-2dc0-46af-8d8c-ad0954810842"), "Medium " },
                    { new Guid("8c820387-853d-40e4-9e07-f1f4f9fe5bf1"), "Hard " }
                });

            migrationBuilder.InsertData(
                table: "RegionSet",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("c47b7142-3f9f-4bbd-80c2-8c29c4934729"), "AKL", "Aucklan", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" });
        }
    }
}
