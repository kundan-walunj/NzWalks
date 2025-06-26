using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_RegionSet_RegionsId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_RegionsId",
                table: "Walks");

            migrationBuilder.DropColumn(
                name: "RegionsId",
                table: "Walks");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_RegionSet_RegionId",
                table: "Walks",
                column: "RegionId",
                principalTable: "RegionSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_RegionSet_RegionId",
                table: "Walks");

            migrationBuilder.DropIndex(
                name: "IX_Walks_RegionId",
                table: "Walks");

            migrationBuilder.AddColumn<Guid>(
                name: "RegionsId",
                table: "Walks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionsId",
                table: "Walks",
                column: "RegionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_RegionSet_RegionsId",
                table: "Walks",
                column: "RegionsId",
                principalTable: "RegionSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
