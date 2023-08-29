using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTccBackend.Migrations
{
    /// <inheritdoc />
    public partial class resolvendoJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_MedicoId",
                table: "Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_MedicoId",
                table: "Usuarios",
                column: "MedicoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_MedicoId",
                table: "Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_MedicoId",
                table: "Usuarios",
                column: "MedicoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
