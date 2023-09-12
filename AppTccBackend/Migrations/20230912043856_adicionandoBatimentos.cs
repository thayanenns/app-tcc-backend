using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTccBackend.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoBatimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Batimentos",
                table: "Medicoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Batimentos",
                table: "Medicoes");
        }
    }
}
