using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tactsoft.Data.Migrations
{
    public partial class UpdateAllTableColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Suppliers",
                newName: "SupplierPhone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Suppliers",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Suppliers",
                newName: "SupplierEmail");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Suppliers",
                newName: "SupplierAddress");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "States",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "EmployeeName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Employees",
                newName: "EmployeeAddress");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "Flag",
                table: "Countries",
                newName: "CountryFlag");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Countries",
                newName: "CountryCurrency");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Countries",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupplierPhone",
                table: "Suppliers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SupplierEmail",
                table: "Suppliers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "SupplierAddress",
                table: "Suppliers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "StateName",
                table: "States",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployeeAddress",
                table: "Employees",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CountryFlag",
                table: "Countries",
                newName: "Flag");

            migrationBuilder.RenameColumn(
                name: "CountryCurrency",
                table: "Countries",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Countries",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Cities",
                newName: "Name");
        }
    }
}
