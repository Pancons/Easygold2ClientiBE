using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                            name: "DbCliente",
                            columns: table => new
                            {
                                Utw_IDClienteAuto = table.Column<int>(type: "int", nullable: false)
                                    .Annotation("SqlServer:Identity", "1, 1"),
                                Utw_NomeConnessione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Utw_StringaConnessione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Utw_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                                Utw_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                                Utw_NegoziAttivabili = table.Column<int>(type: "int", nullable: false),
                                Utw_NegoziVirtuali = table.Column<int>(type: "int", nullable: false),
                                Utw_UtentiAttivi = table.Column<int>(type: "int", nullable: false),
                                Utw_PercorsoReports = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Utw_PercorsoImmagini = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Utw_Blocco = table.Column<bool>(type: "bit", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Clienti", x => x.Utw_IDClienteAuto);
                                migrationBuilder.CreateTable(
                                    name: "DbDatiCliente",
                                    columns: table => new
                            {
                                Dtc_IDCliente = table.Column<int>(type: "int", nullable: false)
                                            .Annotation("SqlServer:Identity", "1, 1"),
                                Dtc_Gioielleria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_RagioneSociale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_Indirizzo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_CAP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_Localita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_StatoRegione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_Nazione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_PartitaIVA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_CodiceFiscale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_REA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Dtc_CapitaleSociale = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                            },
                                    constraints: table =>
                                    {
                                table.PrimaryKey("PK_DbDatiCliente", x => x.Dtc_IDCliente);
                            });
                                migrationBuilder.CreateTable(
                                    name: "DbModuloCliente",
                                    columns: table => new
                            {
                                Mdc_IDCliente = table.Column<int>(type: "int", nullable: false),
                                Mdc_IDModulo = table.Column<int>(type: "int", nullable: false),
                                Mdc_DataAttivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                                Mdc_DataDisattivazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                                Mdc_BloccoModulo = table.Column<bool>(type: "bit", nullable: false),
                                Mdc_DataOraBlocco = table.Column<DateTime>(type: "datetime2", nullable: false),
                                Mdc_Nota = table.Column<string>(type: "nvarchar(max)", nullable: false)
                            },
                                    constraints: table =>
                                    {
                                table.PrimaryKey("PK_DbModuloCliente", x => new { x.Mdc_IDCliente, x.Mdc_IDModulo });
                            });
                                migrationBuilder.CreateTable(
                                    name: "DbModuloEasygold",
                                    columns: table => new
                            {
                                Mde_IDAuto = table.Column<int>(type: "int", nullable: false)
                                            .Annotation("SqlServer:Identity", "1, 1"),
                                Mde_Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Mde_DescrizioneEstesa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                            },
                                    constraints: table =>
                                    {
                                table.PrimaryKey("PK_DbModuloEasygold", x => x.Mde_IDAuto);
                            });
                                migrationBuilder.CreateTable(
                                    name: "DbModuloEasygoldLang",
                                    columns: table => new
                            {
                                Mdeid_ISONum = table.Column<int>(type: "int", nullable: false),
                                Mdeid_ID = table.Column<int>(type: "int", nullable: false),
                                Mdeid_Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Mdeid_DescEstesa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                            },
                                    constraints: table =>
                                    {
                                table.PrimaryKey("PK_DbModuloEasygoldLang", x => new { x.Mdeid_ISONum, x.Mdeid_ID });
                            });
                            });

            migrationBuilder.CreateTable(
                            name: "DbUtente",
                            columns: table => new
                            {
                                Ute_IDUtente = table.Column<int>(type: "int", nullable: false)
                                    .Annotation("SqlServer:Identity", "1, 1"),
                                Ute_NomeUtente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                                Ute_TipoAbilitazione = table.Column<int>(type: "int", nullable: false),
                                Ute_Bloccato = table.Column<bool>(type: "bit", nullable: false),
                                Ute_Nota = table.Column<string>(type: "nvarchar(max)", nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Utenti", x => x.Ute_IDUtente);
                            });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                            name: "DbCliente");

            migrationBuilder.DropTable(
                name: "DbDatiCliente");

            migrationBuilder.DropTable(
                name: "DbModuloCliente");

            migrationBuilder.DropTable(
                name: "DbModuloEasygold");

            migrationBuilder.DropTable(
                name: "DbModuloEasygoldLang");

            migrationBuilder.DropTable(
                name: "DbUtente");
        }
    }
}
