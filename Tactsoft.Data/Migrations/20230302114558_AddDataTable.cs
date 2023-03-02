using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Migrations
{
    public partial class AddDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedBy", "CreatedDateUtc", "DepartmentName", "UpdatedBy", "UpdatedDateUtc" },
                values: new object[,]
                {
                    { 2L, 1L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), "HR", null, null },
                    { 3L, 1L, new DateTimeOffset(new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 6, 0, 0, 0)), "CS", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CountryId", "IdNumber" },
                values: new object[] { 2L, "IT-2310002" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, "IT-2310006" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "korim@gmail.com", "Korim" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "GenderId", "StudentEmail", "StudentName" },
                values: new object[] { 2, "sumi@gmail.com", "Sumi" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "mahabub@gmail.com", "Mahabub" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "salim@gmail.com", "Salim" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "kobir@gmail.com", "Kobir" });

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
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 2L, "HR-2310002" });

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
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 2L, "HR-2310001" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CountryId", "IdNumber" },
                values: new object[] { 1L, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { 1L, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "DepartmentId", "IdNumber" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "rahman@gmail.com", "Rahman" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "GenderId", "StudentEmail", "StudentName" },
                values: new object[] { 1, "rahman@gmail.com", "Rahman" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "rahman@gmail.com", "Rahman" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "rahman@gmail.com", "Rahman" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "StudentEmail", "StudentName" },
                values: new object[] { "rahman@gmail.com", "Rahman" });
        }
    }
}
