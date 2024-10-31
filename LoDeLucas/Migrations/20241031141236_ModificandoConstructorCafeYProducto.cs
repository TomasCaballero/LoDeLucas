using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoDeLucas.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoConstructorCafeYProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Productos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoCafe",
                table: "Productos",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "TipoCafe",
                table: "Productos");
        }
    }
}
