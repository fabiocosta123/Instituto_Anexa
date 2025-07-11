using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarModeloModulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Modulos_CursoId",
                table: "Modulos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modulos_Cursos_CursoId",
                table: "Modulos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modulos_Cursos_CursoId",
                table: "Modulos");

            migrationBuilder.DropIndex(
                name: "IX_Modulos_CursoId",
                table: "Modulos");
        }
    }
}
