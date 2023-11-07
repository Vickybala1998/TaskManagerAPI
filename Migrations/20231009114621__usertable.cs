using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class _usertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "_users");

            migrationBuilder.AddPrimaryKey(
                name: "PK__users",
                table: "_users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__users",
                table: "_users");

            migrationBuilder.RenameTable(
                name: "_users",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
