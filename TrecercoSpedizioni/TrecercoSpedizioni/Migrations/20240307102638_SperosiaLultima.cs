using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrecercoSpedizioni.Migrations
{
    /// <inheritdoc />
    public partial class SperosiaLultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartitaIva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usertype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Spedizioni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSpedizione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false),
                    CittaDestinazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndirizzoDestinatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NominativoDestinatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoSpedizione = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spedizioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spedizioni_Clienti_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clienti",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DettagliSpedizioni",
                columns: table => new
                {
                    idDettagliSpedizione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSpedizione = table.Column<int>(type: "int", nullable: false),
                    StatoSpedizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LuogoCorrente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteSpedizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DettagliSpedizioni", x => x.idDettagliSpedizione);
                    table.ForeignKey(
                        name: "FK_DettagliSpedizioni_Spedizioni_ShippingId",
                        column: x => x.ShippingId,
                        principalTable: "Spedizioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DettagliSpedizioni_ShippingId",
                table: "DettagliSpedizioni",
                column: "ShippingId");

            migrationBuilder.CreateIndex(
                name: "IX_Spedizioni_IdCliente",
                table: "Spedizioni",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DettagliSpedizioni");

            migrationBuilder.DropTable(
                name: "Spedizioni");

            migrationBuilder.DropTable(
                name: "Clienti");
        }
    }
}
