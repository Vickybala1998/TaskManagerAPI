using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "_users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "_users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "_users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "_users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "_users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "_users");
        }
    }
}
