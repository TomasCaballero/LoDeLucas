using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoDeLucas.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionDelContextoTaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Material",
                table: "Productos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material",
                table: "Productos");
        }
    }
}
