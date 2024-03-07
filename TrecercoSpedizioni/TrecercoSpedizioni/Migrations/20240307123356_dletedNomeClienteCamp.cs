using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrecercoSpedizioni.Migrations
{
    /// <inheritdoc />
    public partial class dletedNomeClienteCamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Spedizioni");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Spedizioni",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
