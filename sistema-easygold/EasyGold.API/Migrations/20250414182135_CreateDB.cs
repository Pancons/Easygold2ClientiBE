using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allegati",
                columns: table => new
                {
                    All_IDAllegato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    All_NomeFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    All_Estensione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    All_Dimensione = table.Column<int>(type: "int", nullable: false),
                    All_EntitaRiferimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    All_RecordId = table.Column<int>(type: "int", nullable: false),
                    All_Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    All_ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allegati", x => x.All_IDAllegato);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Log_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Log_TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Log_RecordId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Log_ColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Log_OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Log_NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Log_ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Log_User = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Log_Id);
                });

            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    Utw_IDClienteAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utw_NomeConnessione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Utw_StringaConnessione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Utw_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Utw_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Utw_NegoziAttivabili = table.Column<int>(type: "int", nullable: false),
                    Utw_NegoziVirtuali = table.Column<int>(type: "int", nullable: false),
                    Utw_UtentiAttivi = table.Column<int>(type: "int", nullable: false),
                    Utw_Postazioni = table.Column<int>(type: "int", nullable: false),
                    Utw_PercorsoReports = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Utw_PercorsoImmagini = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Utw_IdStatoCliente = table.Column<int>(type: "int", nullable: true)
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
                    Dtc_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Dtc_Gioielleria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dtc_RagioneSociale = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dtc_Indirizzo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_CAP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dtc_Citta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_StatoRegione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dtc_Nazione = table.Column<int>(type: "int", nullable: false),
                    Dtc_PartitaIVA = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dtc_CodiceFiscale = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dtc_REA = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Dtc_CapitaleSociale = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dtc_RagSocialePrincipale = table.Column<bool>(type: "bit", nullable: false),
                    Dtc_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    Dtc_PEC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteCognome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteCellulare = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_ReferenteWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dtc_Ranking = table.Column<int>(type: "int", nullable: true),
                    Dtc_IDValuta = table.Column<int>(type: "int", nullable: true),
                    Dtc_NumeroContratto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatiClienti", x => x.Dtc_IDDatiCliente);
                });

            migrationBuilder.CreateTable(
                name: "ModuloEasygold",
                columns: table => new
                {
                    Mde_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mde_CodEcomm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mde_Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mde_DescrizioneEstesa = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloEasygold", x => x.Mde_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "ModuloEasygoldLang",
                columns: table => new
                {
                    Mdeid_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mdeid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Mdeid_ID = table.Column<int>(type: "int", nullable: false),
                    Mdeid_Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mdeid_DescEstesa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloEasygoldLang", x => x.Mdeid_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "Nazioni",
                columns: table => new
                {
                    Naz_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naz_Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nazioni", x => x.Naz_id);
                });

            migrationBuilder.CreateTable(
                name: "Negozi",
                columns: table => new
                {
                    Neg_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Neg_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Neg_RagioneSociale = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Neg_NomeNegozio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Neg_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Neg_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Neg_Bloccato = table.Column<bool>(type: "bit", nullable: true),
                    Neg_DataOraBlocco = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Neg_Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negozi", x => x.Neg_id);
                });

            migrationBuilder.CreateTable(
                name: "Ruoli",
                columns: table => new
                {
                    Ur_IDRuolo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ur_Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruoli", x => x.Ur_IDRuolo);
                });

            migrationBuilder.CreateTable(
                name: "StatiCliente",
                columns: table => new
                {
                    Stc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stc_Descrizione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Stc_Colore = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatiCliente", x => x.Stc_id);
                });

            migrationBuilder.CreateTable(
                name: "Valute",
                columns: table => new
                {
                    Val_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Val_Descrizione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Val_Cambio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Val_Simbolo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Val_SimboloRegCassa = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Val_NumeroDecimali = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valute", x => x.Val_id);
                });

            migrationBuilder.CreateTable(
                name: "ModuloClienti",
                columns: table => new
                {
                    Mdc_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mdc_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Mdc_IDModulo = table.Column<int>(type: "int", nullable: false),
                    Mdc_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mdc_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mdc_BloccoModulo = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Ute_IDUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ute_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ute_Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ute_NomeUtente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ute_IDRuolo = table.Column<int>(type: "int", nullable: false),
                    Ute_Bloccato = table.Column<bool>(type: "bit", nullable: false),
                    Ute_Nota = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ute_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Ute_IDUtente);
                    table.ForeignKey(
                        name: "FK_Utenti_Ruoli_Ute_IDRuolo",
                        column: x => x.Ute_IDRuolo,
                        principalTable: "Ruoli",
                        principalColumn: "Ur_IDRuolo",
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

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_Ute_IDRuolo",
                table: "Utenti",
                column: "Ute_IDRuolo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allegati");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "DatiClienti");

            migrationBuilder.DropTable(
                name: "ModuloClienti");

            migrationBuilder.DropTable(
                name: "ModuloEasygoldLang");

            migrationBuilder.DropTable(
                name: "Nazioni");

            migrationBuilder.DropTable(
                name: "Negozi");

            migrationBuilder.DropTable(
                name: "StatiCliente");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Valute");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "ModuloEasygold");

            migrationBuilder.DropTable(
                name: "Ruoli");
        }
    }
}
