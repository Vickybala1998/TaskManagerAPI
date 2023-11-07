using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeTaskDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "_tasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "_tasks");
        }
    }
}
