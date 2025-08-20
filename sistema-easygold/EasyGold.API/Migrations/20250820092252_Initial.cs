using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    All_ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Utw_IdStatoCliente = table.Column<int>(type: "int", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Dtc_NumeroContratto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Mde_DescrizioneEstesa = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Mdeid_DescEstesa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Naz_Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Neg_Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Ur_Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Stc_Colore = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatiCliente", x => x.Stc_id);
                });

            migrationBuilder.CreateTable(
                name: "tbco_cauProgressivi",
                columns: table => new
                {
                    Cpr_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpr_Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cpr_CalcGiacenza = table.Column<int>(type: "int", nullable: false),
                    Cpr_CalcDisponibilita = table.Column<int>(type: "int", nullable: false),
                    Cpr_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_cauProgressivi", x => x.Cpr_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_causali",
                columns: table => new
                {
                    Cac_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cac_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cac_IDDoveUso = table.Column<int>(type: "int", nullable: false),
                    Cac_IDProgressivo = table.Column<int>(type: "int", nullable: false),
                    Cac_IDTipoAnagrafica = table.Column<int>(type: "int", nullable: false),
                    Cac_IDTipoIVA = table.Column<int>(type: "int", nullable: false),
                    Cac_Annulla = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_causali", x => x.Cac_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_documentiFunzione",
                columns: table => new
                {
                    Dof_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dof_Funzione = table.Column<int>(type: "int", nullable: false),
                    Dof_ISONum = table.Column<int>(type: "int", nullable: false),
                    Dof_Documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dof_TipoDoc = table.Column<int>(type: "int", nullable: false),
                    Dof_Sequenza = table.Column<int>(type: "int", nullable: false),
                    Dof_Annulla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_documentiFunzione", x => x.Dof_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_funzioni",
                columns: table => new
                {
                    Abl_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abl_IDPadre = table.Column<int>(type: "int", nullable: false),
                    Abl_DescFunzione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Abl_DescFunzioneEstesa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Abl_Annullato = table.Column<bool>(type: "bit", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_funzioni", x => x.Abl_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_idiomiEasygold",
                columns: table => new
                {
                    Idm_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idm_ISONum = table.Column<int>(type: "int", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_idiomiEasygold", x => x.Idm_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_indirizzi",
                columns: table => new
                {
                    Str_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Str_ISO1 = table.Column<int>(type: "int", nullable: false),
                    Str_Descrizione = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Str_CodLocalita = table.Column<int>(type: "int", nullable: false),
                    Str_CAP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_indirizzi", x => x.Str_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_ISONazioni",
                columns: table => new
                {
                    Ntn_ISO1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ntn_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ntn_ISO1A2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Ntn_ISO1A3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Ntn_PrefTelef = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ntn_Continente = table.Column<int>(type: "int", nullable: false),
                    Ntn_ContinenteLegale = table.Column<int>(type: "int", nullable: false),
                    Ntn_Appartiene = table.Column<int>(type: "int", nullable: false),
                    Ntn_Capitale = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_CapitaleDeFacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_CapitaleAmm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_CapitaleIdioma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_IDValuta = table.Column<int>(type: "int", nullable: false),
                    Ntn_LunghezzaCAP = table.Column<int>(type: "int", nullable: false),
                    Ntn_NomePI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ntn_TipoPI = table.Column<int>(type: "int", nullable: false),
                    Ntn_LunghezzaPI = table.Column<int>(type: "int", nullable: false),
                    Ntn_NomeCF = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ntn_TipoCF = table.Column<int>(type: "int", nullable: false),
                    Ntn_LunghezzaCF = table.Column<int>(type: "int", nullable: false),
                    Ntn_DescStatoRegione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_StatoRegione = table.Column<bool>(type: "bit", nullable: false),
                    Ntn_LungSiglaProv = table.Column<int>(type: "int", nullable: false),
                    Ntn_ProvSiNo = table.Column<bool>(type: "bit", nullable: false),
                    Ntn_Province = table.Column<bool>(type: "bit", nullable: false),
                    Ntn_Localita = table.Column<bool>(type: "bit", nullable: false),
                    Ntn_Indirizzi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_ISONazioni", x => x.Ntn_ISO1);
                });

            migrationBuilder.CreateTable(
                name: "tbco_localita",
                columns: table => new
                {
                    Str_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Str_ISO1 = table.Column<int>(type: "int", nullable: false),
                    Str_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Str_CodStatoRegione = table.Column<int>(type: "int", nullable: false),
                    Str_CodProvincia = table.Column<int>(type: "int", nullable: true),
                    Str_CAP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_localita", x => x.Str_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_moduliStampe",
                columns: table => new
                {
                    Mst_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mst_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mst_NomeModulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mst_TipoModulo = table.Column<int>(type: "int", nullable: false),
                    Mst_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_moduliStampe", x => x.Mst_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_nazioniMondo",
                columns: table => new
                {
                    Nzm_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nzm_Nazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzm_ISOAlfa2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nzm_ISOAlfa3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nzm_ISONum = table.Column<int>(type: "int", nullable: false),
                    Nzm_PrefTelefonico = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nzm_CapitaleIure = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzm_CapitaleFatto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzm_CapitaleAmm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzm_CapitaleIdioma = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_nazioniMondo", x => x.Nzm_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_province",
                columns: table => new
                {
                    Str_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Str_ISO1 = table.Column<int>(type: "int", nullable: false),
                    Str_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Str_SiglaTargaAuto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Str_CodStatoRegione = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_province", x => x.Str_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_SessioniEasyGold",
                columns: table => new
                {
                    Sse_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sse_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Sse_IDUtente = table.Column<int>(type: "int", nullable: false),
                    Sse_DataLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sse_SesScaduta = table.Column<bool>(type: "bit", nullable: false),
                    Sse_DataLogout = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sse_sesForzata = table.Column<bool>(type: "bit", nullable: true),
                    Sse_DataLogoutForzato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_SessioniEasyGold", x => x.Sse_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_statoRegioni",
                columns: table => new
                {
                    Str_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Str_ISO1 = table.Column<int>(type: "int", nullable: false),
                    Str_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Str_CodCapoluogo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_statoRegioni", x => x.Str_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_tipoPermesso",
                columns: table => new
                {
                    Tpa_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tpa_TipoPermesso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tpa_LivelloPermesso = table.Column<int>(type: "int", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_tipoPermesso", x => x.Tpa_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_tipoPermesso_lang",
                columns: table => new
                {
                    Tpaid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Tpaid_ID = table.Column<int>(type: "int", nullable: false),
                    Tpaid_TipoAbilitazione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_tipoPermesso_lang", x => new { x.Tpaid_ISONum, x.Tpaid_ID });
                });

            migrationBuilder.CreateTable(
                name: "tbco_tipoTagProdotti",
                columns: table => new
                {
                    Tpt_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tpt_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tpt_TipoTag = table.Column<int>(type: "int", nullable: false),
                    Tpt_NumGiorni = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_tipoTagProdotti", x => x.Tpt_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbco_ValoriTabelle",
                columns: table => new
                {
                    rowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rowCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lst_oldId = table.Column<int>(type: "int", nullable: true),
                    lst_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lst_itemType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_ValoriTabelle", x => x.rowId);
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
                    Val_NumeroDecimali = table.Column<int>(type: "int", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Mdc_Nota = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Ute_Nota = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ute_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "tbco_cauProgressivi_lang",
                columns: table => new
                {
                    Prcid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Prcid_ID = table.Column<int>(type: "int", nullable: false),
                    Prcid_Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_cauProgressivi_lang", x => new { x.Prcid_ISONum, x.Prcid_ID });
                    table.ForeignKey(
                        name: "FK_tbco_cauProgressivi_lang_tbco_cauProgressivi_Prcid_ID",
                        column: x => x.Prcid_ID,
                        principalTable: "tbco_cauProgressivi",
                        principalColumn: "Cpr_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_cauOrdinamento",
                columns: table => new
                {
                    Cao_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cao_ID = table.Column<int>(type: "int", nullable: false),
                    Cao_Ordinamento = table.Column<int>(type: "int", nullable: false),
                    DbCausaliComuneCac_IDAuto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_cauOrdinamento", x => x.Cao_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbco_cauOrdinamento_tbco_causali_Cao_ID",
                        column: x => x.Cao_ID,
                        principalTable: "tbco_causali",
                        principalColumn: "Cac_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbco_cauOrdinamento_tbco_causali_DbCausaliComuneCac_IDAuto",
                        column: x => x.DbCausaliComuneCac_IDAuto,
                        principalTable: "tbco_causali",
                        principalColumn: "Cac_IDAuto");
                });

            migrationBuilder.CreateTable(
                name: "tbco_causali_lang",
                columns: table => new
                {
                    Cac_ISONum = table.Column<int>(type: "int", nullable: false),
                    Cac_ID = table.Column<int>(type: "int", nullable: false),
                    Cac_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cac_IDAuto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_causali_lang", x => new { x.Cac_ISONum, x.Cac_ID });
                    table.ForeignKey(
                        name: "FK_tbco_causali_lang_tbco_causali_Cac_ID",
                        column: x => x.Cac_ID,
                        principalTable: "tbco_causali",
                        principalColumn: "Cac_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_funzioni_lang",
                columns: table => new
                {
                    Ablid_ID = table.Column<int>(type: "int", nullable: false),
                    Ablid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Ablid_DescFunzione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ablid_descFunzioneEstesa = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_funzioni_lang", x => new { x.Ablid_ID, x.Ablid_ISONum });
                    table.ForeignKey(
                        name: "FK_tbco_funzioni_lang_tbco_funzioni_Ablid_ID",
                        column: x => x.Ablid_ID,
                        principalTable: "tbco_funzioni",
                        principalColumn: "Abl_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_indirizzi_lang",
                columns: table => new
                {
                    Strid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Strid_ID = table.Column<int>(type: "int", nullable: false),
                    Strid_Descrizione = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_indirizzi_lang", x => new { x.Strid_ISONum, x.Strid_ID });
                    table.ForeignKey(
                        name: "FK_tbco_indirizzi_lang_tbco_indirizzi_Strid_ID",
                        column: x => x.Strid_ID,
                        principalTable: "tbco_indirizzi",
                        principalColumn: "Str_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_id_ISONazioni",
                columns: table => new
                {
                    Ntnid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Ntnid_ID = table.Column<int>(type: "int", nullable: false),
                    Ntnid_Nazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntnid_Capitale = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_CapitaleDeFacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ntn_CapitaleAmm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_id_ISONazioni", x => new { x.Ntnid_ISONum, x.Ntnid_ID });
                    table.ForeignKey(
                        name: "FK_tbco_id_ISONazioni_tbco_ISONazioni_Ntnid_ID",
                        column: x => x.Ntnid_ID,
                        principalTable: "tbco_ISONazioni",
                        principalColumn: "Ntn_ISO1",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_localita_lang",
                columns: table => new
                {
                    Strid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Strid_ID = table.Column<int>(type: "int", nullable: false),
                    Strid_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_localita_lang", x => new { x.Strid_ISONum, x.Strid_ID });
                    table.ForeignKey(
                        name: "FK_tbco_localita_lang_tbco_localita_Strid_ID",
                        column: x => x.Strid_ID,
                        principalTable: "tbco_localita",
                        principalColumn: "Str_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_nazioniMondo_lang",
                columns: table => new
                {
                    Nzmid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Nzmid_ID = table.Column<int>(type: "int", nullable: false),
                    Nzmid_Nazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzmid_CapitaleIure = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzmid_CapitaleFatto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nzmid_CapitaleAmm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_nazioniMondo_lang", x => new { x.Nzmid_ID, x.Nzmid_ISONum });
                    table.ForeignKey(
                        name: "FK_tbco_nazioniMondo_lang_tbco_nazioniMondo_Nzmid_ID",
                        column: x => x.Nzmid_ID,
                        principalTable: "tbco_nazioniMondo",
                        principalColumn: "Nzm_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_province_lang",
                columns: table => new
                {
                    Strid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Strid_ID = table.Column<int>(type: "int", nullable: false),
                    Strid_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_province_lang", x => new { x.Strid_ISONum, x.Strid_ID });
                    table.ForeignKey(
                        name: "FK_tbco_province_lang_tbco_province_Strid_ID",
                        column: x => x.Strid_ID,
                        principalTable: "tbco_province",
                        principalColumn: "Str_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbco_id_statoRegioni",
                columns: table => new
                {
                    Strid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Strid_ID = table.Column<int>(type: "int", nullable: false),
                    Strid_Descrizione = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_id_statoRegioni", x => new { x.Strid_ISONum, x.Strid_ID });
                    table.ForeignKey(
                        name: "FK_tbco_id_statoRegioni_tbco_statoRegioni_Strid_ID",
                        column: x => x.Strid_ID,
                        principalTable: "tbco_statoRegioni",
                        principalColumn: "Str_IDAuto",
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
                name: "IX_tbco_cauOrdinamento_Cao_ID",
                table: "tbco_cauOrdinamento",
                column: "Cao_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_cauOrdinamento_DbCausaliComuneCac_IDAuto",
                table: "tbco_cauOrdinamento",
                column: "DbCausaliComuneCac_IDAuto");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_cauProgressivi_lang_Prcid_ID",
                table: "tbco_cauProgressivi_lang",
                column: "Prcid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_causali_lang_Cac_ID",
                table: "tbco_causali_lang",
                column: "Cac_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_id_ISONazioni_Ntnid_ID",
                table: "tbco_id_ISONazioni",
                column: "Ntnid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_id_statoRegioni_Strid_ID",
                table: "tbco_id_statoRegioni",
                column: "Strid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_indirizzi_lang_Strid_ID",
                table: "tbco_indirizzi_lang",
                column: "Strid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_localita_lang_Strid_ID",
                table: "tbco_localita_lang",
                column: "Strid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_province_lang_Strid_ID",
                table: "tbco_province_lang",
                column: "Strid_ID");

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
                name: "tbco_cauOrdinamento");

            migrationBuilder.DropTable(
                name: "tbco_cauProgressivi_lang");

            migrationBuilder.DropTable(
                name: "tbco_causali_lang");

            migrationBuilder.DropTable(
                name: "tbco_documentiFunzione");

            migrationBuilder.DropTable(
                name: "tbco_funzioni_lang");

            migrationBuilder.DropTable(
                name: "tbco_id_ISONazioni");

            migrationBuilder.DropTable(
                name: "tbco_id_statoRegioni");

            migrationBuilder.DropTable(
                name: "tbco_idiomiEasygold");

            migrationBuilder.DropTable(
                name: "tbco_indirizzi_lang");

            migrationBuilder.DropTable(
                name: "tbco_localita_lang");

            migrationBuilder.DropTable(
                name: "tbco_moduliStampe");

            migrationBuilder.DropTable(
                name: "tbco_nazioniMondo_lang");

            migrationBuilder.DropTable(
                name: "tbco_province_lang");

            migrationBuilder.DropTable(
                name: "tbco_SessioniEasyGold");

            migrationBuilder.DropTable(
                name: "tbco_tipoPermesso");

            migrationBuilder.DropTable(
                name: "tbco_tipoPermesso_lang");

            migrationBuilder.DropTable(
                name: "tbco_tipoTagProdotti");

            migrationBuilder.DropTable(
                name: "tbco_ValoriTabelle");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Valute");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "ModuloEasygold");

            migrationBuilder.DropTable(
                name: "tbco_cauProgressivi");

            migrationBuilder.DropTable(
                name: "tbco_causali");

            migrationBuilder.DropTable(
                name: "tbco_funzioni");

            migrationBuilder.DropTable(
                name: "tbco_ISONazioni");

            migrationBuilder.DropTable(
                name: "tbco_statoRegioni");

            migrationBuilder.DropTable(
                name: "tbco_indirizzi");

            migrationBuilder.DropTable(
                name: "tbco_localita");

            migrationBuilder.DropTable(
                name: "tbco_nazioniMondo");

            migrationBuilder.DropTable(
                name: "tbco_province");

            migrationBuilder.DropTable(
                name: "Ruoli");
        }
    }
}
