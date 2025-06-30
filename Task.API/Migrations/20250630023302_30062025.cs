using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task.API.Migrations
{
    /// <inheritdoc />
    public partial class _30062025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TaskData",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "TaskData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FinishDate", "Status" },
                values: new object[] { new DateTime(2025, 6, 30, 2, 33, 1, 716, DateTimeKind.Utc).AddTicks(6601), new DateTime(2025, 7, 10, 2, 33, 1, 716, DateTimeKind.Utc).AddTicks(6182), "Pending" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "TaskData",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "TaskData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FinishDate", "Status" },
                values: new object[] { new DateTime(2025, 6, 28, 2, 5, 1, 191, DateTimeKind.Utc).AddTicks(5048), new DateTime(2025, 7, 8, 2, 5, 1, 191, DateTimeKind.Utc).AddTicks(4750), false });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 28, 2, 5, 1, 191, DateTimeKind.Utc).AddTicks(1998));
        }
    }
}
