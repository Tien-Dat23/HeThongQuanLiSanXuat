using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeThongQuanLiSanXuat_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMachineCodeToMachines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "machine_code",
                table: "machines",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "machine_code",
                table: "machines");
        }
    }
}
