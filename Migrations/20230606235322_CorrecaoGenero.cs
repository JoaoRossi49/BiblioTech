using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioTech.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdAutor",
                table: "Genero",
                newName: "IdGenero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdGenero",
                table: "Genero",
                newName: "IdAutor");
        }
    }
}
