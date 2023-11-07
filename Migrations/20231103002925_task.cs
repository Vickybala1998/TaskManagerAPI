using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    assignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tasks", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_tasks");
        }
    }
}
