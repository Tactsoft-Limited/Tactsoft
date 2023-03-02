using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Migrations
{
    public partial class AddDataTableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, "IT-2310001" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IdNumber",
                value: "HR-2310001");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 3L, "CS-2310001" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, "IT-2310002" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IdNumber",
                value: "HR-2310002");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 3L, "CS-2310002" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 3L, "CS-2310002" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IdNumber",
                value: "HR-2310002");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, "IT-2310002" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 3L, "CS-2310001" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5L,
                column: "IdNumber",
                value: "HR-2310001");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, "IT-2310006" });
        }
    }
}
