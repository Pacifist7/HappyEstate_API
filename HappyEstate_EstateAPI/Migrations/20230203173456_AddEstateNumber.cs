using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyEstateEstateAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddEstateNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstateNumbers",
                columns: table => new
                {
                    EstateNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateNumbers", x => x.EstateNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateNumbers");

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 21, 11, 53, 41, 716, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 21, 11, 53, 41, 716, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 21, 11, 53, 41, 716, DateTimeKind.Local).AddTicks(3434));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 21, 11, 53, 41, 716, DateTimeKind.Local).AddTicks(3436));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 1, 21, 11, 53, 41, 716, DateTimeKind.Local).AddTicks(3438));
        }
    }
}
