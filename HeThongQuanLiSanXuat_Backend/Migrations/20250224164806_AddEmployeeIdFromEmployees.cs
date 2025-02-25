using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongQuanLiSanXuat_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeIdFromEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "employee_id",
                table: "employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employee_id",
                table: "employees");
        }
    }
}
