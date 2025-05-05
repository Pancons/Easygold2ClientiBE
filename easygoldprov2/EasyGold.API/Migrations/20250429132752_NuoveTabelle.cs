using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class NuoveTabelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatiClienti");

            migrationBuilder.DropTable(
                name: "ModuloClienti");

            migrationBuilder.DropTable(
                name: "StatiCliente");

            migrationBuilder.DropTable(
                name: "tbco_ValoriTabelle");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.CreateTable(
                name: "ConfigLag",
                columns: table => new
                {
                    Sysid_ISONum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sysid_ID = table.Column<int>(type: "int", nullable: false),
                    Sysid_NomeCampo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigLag", x => x.Sysid_ISONum);
                });

            migrationBuilder.CreateTable(
                name: "Configurazioni",
                columns: table => new
                {
                    Sys_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sys_Sezione = table.Column<int>(type: "int", nullable: false),
                    Sys_Nazione = table.Column<int>(type: "int", nullable: false),
                    Sys_NomeCampo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sys_TipoCampo = table.Column<int>(type: "int", nullable: false),
                    Sys_Valore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sys_Lunghezza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurazioni", x => x.Sys_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "NumeriRegIVA",
                columns: table => new
                {
                    RowIDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowIDRegIVA = table.Column<int>(type: "int", nullable: false),
                    Nri_Anno = table.Column<int>(type: "int", nullable: false),
                    Nri_NumFattura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumeriRegIVA", x => x.RowIDAuto);
                });

            migrationBuilder.CreateTable(
                name: "RegistriIVA",
                columns: table => new
                {
                    RowIdAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rgi_Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rgi_Prefisso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rgi_Suffisso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Rgi_Annulla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistriIVA", x => x.RowIdAuto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigLag");

            migrationBuilder.DropTable(
                name: "Configurazioni");

            migrationBuilder.DropTable(
                name: "NumeriRegIVA");

            migrationBuilder.DropTable(
                name: "RegistriIVA");

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Utw_IDClienteAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utw_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Utw_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Utw_IdStatoCliente = table.Column<int>(type: "int", nullable: true),
                    Utw_NegoziAttivabili = table.Column<int>(type: "int", nullable: false),
                    Utw_NegoziVirtuali = table.Column<int>(type: "int", nullable: false),
                    Utw_NomeConnessione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Utw_PercorsoImmagini = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Utw_PercorsoReports = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Utw_Postazioni = table.Column<int>(type: "int", nullable: false),
                    Utw_StringaConnessione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Utw_UtentiAttivi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.Utw_IDClienteAuto);
                });

            migrationBuilder.CreateTable(
                name: "DatiClienti",
                columns: table => new
                {
                    Dtc_IDDatiCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dtc_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    Dtc_CAP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dtc_CapitaleSociale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dtc_Citta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_CodiceFiscale = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dtc_Gioielleria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dtc_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Dtc_IDValuta = table.Column<int>(type: "int", nullable: true),
                    Dtc_Indirizzo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_Nazione = table.Column<int>(type: "int", nullable: false),
                    Dtc_NumeroContratto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_PEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_PartitaIVA = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dtc_Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_REA = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dtc_RagSocialePrincipale = table.Column<bool>(type: "bit", nullable: false),
                    Dtc_RagioneSociale = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dtc_Ranking = table.Column<int>(type: "int", nullable: true),
                    Dtc_ReferenteCellulare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteCognome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_StatoRegione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatiClienti", x => x.Dtc_IDDatiCliente);
                });

            migrationBuilder.CreateTable(
                name: "StatiCliente",
                columns: table => new
                {
                    Stc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stc_Colore = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Stc_Descrizione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatiCliente", x => x.Stc_id);
                });

            migrationBuilder.CreateTable(
                name: "tbco_ValoriTabelle",
                columns: table => new
                {
                    rowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lst_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lst_itemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lst_oldId = table.Column<int>(type: "int", nullable: true),
                    rowCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_ValoriTabelle", x => x.rowId);
                });

            migrationBuilder.CreateTable(
                name: "ModuloClienti",
                columns: table => new
                {
                    Mdc_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mdc_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Mdc_IDModulo = table.Column<int>(type: "int", nullable: false),
                    Mdc_BloccoModulo = table.Column<bool>(type: "bit", nullable: false),
                    Mdc_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mdc_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mdc_DataOraBlocco = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mdc_Nota = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloClienti", x => x.Mdc_IDAuto);
                    table.ForeignKey(
                        name: "FK_ModuloClienti_Clienti_Mdc_IDCliente",
                        column: x => x.Mdc_IDCliente,
                        principalTable: "Clienti",
                        principalColumn: "Utw_IDClienteAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloClienti_ModuloEasygold_Mdc_IDModulo",
                        column: x => x.Mdc_IDModulo,
                        principalTable: "ModuloEasygold",
                        principalColumn: "Mde_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuloClienti_Mdc_IDCliente",
                table: "ModuloClienti",
                column: "Mdc_IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloClienti_Mdc_IDModulo",
                table: "ModuloClienti",
                column: "Mdc_IDModulo");
        }
    }
}
