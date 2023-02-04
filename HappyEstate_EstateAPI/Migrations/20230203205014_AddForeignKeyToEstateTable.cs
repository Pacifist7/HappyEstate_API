using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyEstateEstateAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToEstateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstateID",
                table: "EstateNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 13, 50, 14, 89, DateTimeKind.Local).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 13, 50, 14, 89, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 13, 50, 14, 89, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 13, 50, 14, 89, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 13, 50, 14, 89, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.CreateIndex(
                name: "IX_EstateNumbers_EstateID",
                table: "EstateNumbers",
                column: "EstateID");

            migrationBuilder.AddForeignKey(
                name: "FK_EstateNumbers_Estates_EstateID",
                table: "EstateNumbers",
                column: "EstateID",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstateNumbers_Estates_EstateID",
                table: "EstateNumbers");

            migrationBuilder.DropIndex(
                name: "IX_EstateNumbers_EstateID",
                table: "EstateNumbers");

            migrationBuilder.DropColumn(
                name: "EstateID",
                table: "EstateNumbers");

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 10, 34, 56, 745, DateTimeKind.Local).AddTicks(2730));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 10, 34, 56, 745, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 10, 34, 56, 745, DateTimeKind.Local).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 10, 34, 56, 745, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 10, 34, 56, 745, DateTimeKind.Local).AddTicks(2787));
        }
    }
}
