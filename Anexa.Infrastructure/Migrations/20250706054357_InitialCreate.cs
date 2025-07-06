using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anexa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_Rua = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco_Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Endereco_Bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco_Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Endereco_Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Endereco_Cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
