using System;
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
                name: "tbcl_gruppi",
                columns: table => new
                {
                    Grp_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grp_NomeGruppo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grp_DesGruppo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Grp_SuperAdmin = table.Column<bool>(type: "bit", nullable: true),
                    Grp_Bloccato = table.Column<bool>(type: "bit", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_gruppi", x => x.Grp_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_nazioneNegozio",
                columns: table => new
                {
                    Nne_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nne_IDNegozio = table.Column<int>(type: "int", nullable: false),
                    Nne_IDTipoCampo = table.Column<int>(type: "int", nullable: false),
                    Nne_Valore = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_nazioneNegozio", x => x.Nne_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_negoziAltro",
                columns: table => new
                {
                    Nea_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nea_IDNazione = table.Column<int>(type: "int", nullable: false),
                    Nea_IDValuta = table.Column<int>(type: "int", nullable: false),
                    Nea_IDListino = table.Column<int>(type: "int", nullable: false),
                    Nea_IDAliquotaIVA = table.Column<int>(type: "int", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_negoziAltro", x => x.Nea_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_testataPostazioni",
                columns: table => new
                {
                    tpo_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tpo_descizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tpo_registratore = table.Column<bool>(type: "bit", nullable: false),
                    tpo_stampanti = table.Column<bool>(type: "bit", nullable: false),
                    tpo_card = table.Column<bool>(type: "bit", nullable: false),
                    tpo_annullato = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_testataPostazioni", x => x.tpo_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_tipoPw",
                columns: table => new
                {
                    Tpp_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tpp_TipoPw = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipoPw", x => x.Tpp_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_tipopw_Lang",
                columns: table => new
                {
                    Tppid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Tppid_ID = table.Column<int>(type: "int", nullable: false),
                    Tppid_TipiPw = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipopw_Lang", x => new { x.Tppid_ISONum, x.Tppid_ID });
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
                name: "tbco_testataPostazioni_lang",
                columns: table => new
                {
                    tpoid_ISONum = table.Column<int>(type: "int", nullable: false),
                    tpoid_ID = table.Column<int>(type: "int", nullable: false),
                    tpoid_Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_testataPostazioni_lang", x => new { x.tpoid_ISONum, x.tpoid_ID });
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
                name: "tbcl_regFiscale",
                columns: table => new
                {
                    Rfi_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rfi_Descrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rfi_TipoRegFiscale = table.Column<int>(type: "int", nullable: false),
                    Rfi_CodNegozio = table.Column<int>(type: "int", nullable: false),
                    Rfi_Matricola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rfi_NumeroChiusure = table.Column<int>(type: "int", nullable: false),
                    Rfi_UltimaDataChiusura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rfi_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_regFiscale", x => x.Rfi_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_regFiscale_Negozi_Rfi_CodNegozio",
                        column: x => x.Rfi_CodNegozio,
                        principalTable: "Negozi",
                        principalColumn: "Neg_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_gruppi_lang",
                columns: table => new
                {
                    grpid_ISONum = table.Column<int>(type: "int", nullable: false),
                    grpid_ID = table.Column<int>(type: "int", nullable: false),
                    grpid_nomeGruppo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    grpid_desGruppo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DbGruppiGrp_IDAuto = table.Column<int>(type: "int", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_gruppi_lang", x => new { x.grpid_ISONum, x.grpid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_gruppi_lang_tbcl_gruppi_DbGruppiGrp_IDAuto",
                        column: x => x.DbGruppiGrp_IDAuto,
                        principalTable: "tbcl_gruppi",
                        principalColumn: "Grp_IDAuto");
                    table.ForeignKey(
                        name: "FK_tbcl_gruppi_lang_tbcl_gruppi_grpid_ID",
                        column: x => x.grpid_ID,
                        principalTable: "tbcl_gruppi",
                        principalColumn: "Grp_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_utenti",
                columns: table => new
                {
                    Ute_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ute_IDUtente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Ute_NomeUtente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ute_IDGruppo = table.Column<int>(type: "int", nullable: false),
                    Ute_IDIdioma = table.Column<int>(type: "int", nullable: false),
                    Ute_AbilitaTuttiNegozi = table.Column<bool>(type: "bit", nullable: false),
                    Ute_AbilitaCassa = table.Column<bool>(type: "bit", nullable: false),
                    Ute_AbilitaEliminaProd = table.Column<bool>(type: "bit", nullable: false),
                    Ute_Bloccato = table.Column<bool>(type: "bit", nullable: false),
                    Ute_PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ute_ResetTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ute_Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_utenti", x => x.Ute_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_utenti_tbcl_gruppi_Ute_IDGruppo",
                        column: x => x.Ute_IDGruppo,
                        principalTable: "tbcl_gruppi",
                        principalColumn: "Grp_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_lettorePostazioni",
                columns: table => new
                {
                    Lpo_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lpo_IDPostazione = table.Column<int>(type: "int", nullable: false),
                    Lpo_IDLettore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lpo_DevLettore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lpo_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_lettorePostazioni", x => x.Lpo_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_lettorePostazioni_tbcl_testataPostazioni_Lpo_IDPostazione",
                        column: x => x.Lpo_IDPostazione,
                        principalTable: "tbcl_testataPostazioni",
                        principalColumn: "tpo_IDAuto",
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
                name: "tbcl_stampePostazioni",
                columns: table => new
                {
                    Tpo_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tpo_IDPostazione = table.Column<int>(type: "int", nullable: false),
                    Tpo_IDStampa = table.Column<int>(type: "int", nullable: false),
                    Tpo_IPDevice = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tpo_Device = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tpo_Diretta = table.Column<bool>(type: "bit", nullable: false),
                    Tpo_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_stampePostazioni", x => x.Tpo_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_stampePostazioni_tbcl_testataPostazioni_Tpo_IDPostazione",
                        column: x => x.Tpo_IDPostazione,
                        principalTable: "tbcl_testataPostazioni",
                        principalColumn: "tpo_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_stampePostazioni_tbco_moduliStampe_Tpo_IDStampa",
                        column: x => x.Tpo_IDStampa,
                        principalTable: "tbco_moduliStampe",
                        principalColumn: "Mst_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_PermessiGruppo",
                columns: table => new
                {
                    Abg_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abg_IDGruppo = table.Column<int>(type: "int", nullable: false),
                    Abg_IDFunzione = table.Column<int>(type: "int", nullable: false),
                    Abg_IDTipoPermesso = table.Column<int>(type: "int", nullable: false),
                    DbTipoPermessoTpa_IDAuto = table.Column<int>(type: "int", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_PermessiGruppo", x => x.Abg_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_PermessiGruppo_tbcl_gruppi_Abg_IDGruppo",
                        column: x => x.Abg_IDGruppo,
                        principalTable: "tbcl_gruppi",
                        principalColumn: "Grp_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_PermessiGruppo_tbco_funzioni_Abg_IDFunzione",
                        column: x => x.Abg_IDFunzione,
                        principalTable: "tbco_funzioni",
                        principalColumn: "Abl_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_PermessiGruppo_tbco_tipoPermesso_DbTipoPermessoTpa_IDAuto",
                        column: x => x.DbTipoPermessoTpa_IDAuto,
                        principalTable: "tbco_tipoPermesso",
                        principalColumn: "Tpa_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_fiscalePostazioni",
                columns: table => new
                {
                    Fpo_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fpo_IDPostazione = table.Column<int>(type: "int", nullable: false),
                    Fpo_IDRegFiscale = table.Column<int>(type: "int", nullable: false),
                    Fpo_IPPath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fpo_Attivo = table.Column<bool>(type: "bit", nullable: false),
                    Fpo_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_fiscalePostazioni", x => x.Fpo_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_fiscalePostazioni_tbcl_regFiscale_Fpo_IDRegFiscale",
                        column: x => x.Fpo_IDRegFiscale,
                        principalTable: "tbcl_regFiscale",
                        principalColumn: "Rfi_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_fiscalePostazioni_tbcl_testataPostazioni_Fpo_IDPostazione",
                        column: x => x.Fpo_IDPostazione,
                        principalTable: "tbcl_testataPostazioni",
                        principalColumn: "tpo_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_pwUtenti",
                columns: table => new
                {
                    Utp_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utp_IDUtente = table.Column<int>(type: "int", nullable: false),
                    Utp_TipoPw = table.Column<int>(type: "int", nullable: false),
                    Utp_PwUtente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_pwUtenti", x => x.Utp_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_pwUtenti_tbcl_tipoPw_Utp_TipoPw",
                        column: x => x.Utp_TipoPw,
                        principalTable: "tbcl_tipoPw",
                        principalColumn: "Tpp_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_pwUtenti_tbcl_utenti_Utp_IDUtente",
                        column: x => x.Utp_IDUtente,
                        principalTable: "tbcl_utenti",
                        principalColumn: "Ute_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_refresh_token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbcl_refresh_token_tbcl_utenti_UserId",
                        column: x => x.UserId,
                        principalTable: "tbcl_utenti",
                        principalColumn: "Ute_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_utenteNegozi",
                columns: table => new
                {
                    Utn_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Utn_IDUtente = table.Column<int>(type: "int", nullable: false),
                    Utn_IDNegozio = table.Column<int>(type: "int", nullable: false),
                    Utn_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    Utn_Default = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_utenteNegozi", x => x.Utn_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_utenteNegozi_Negozi_Utn_IDNegozio",
                        column: x => x.Utn_IDNegozio,
                        principalTable: "Negozi",
                        principalColumn: "Neg_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_utenteNegozi_tbcl_utenti_Utn_IDUtente",
                        column: x => x.Utn_IDUtente,
                        principalTable: "tbcl_utenti",
                        principalColumn: "Ute_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_utentePostazioni",
                columns: table => new
                {
                    Upo_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Upo_IdUtente_IDNegozio = table.Column<int>(type: "int", nullable: false),
                    Upo_IDPostazione = table.Column<int>(type: "int", nullable: false),
                    Upo_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    Upo_IDUtente = table.Column<int>(type: "int", nullable: false),
                    Upo_IDNegozio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_utentePostazioni", x => x.Upo_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_utentePostazioni_Negozi_Upo_IDNegozio",
                        column: x => x.Upo_IDNegozio,
                        principalTable: "Negozi",
                        principalColumn: "Neg_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_utentePostazioni_tbcl_testataPostazioni_Upo_IDPostazione",
                        column: x => x.Upo_IDPostazione,
                        principalTable: "tbcl_testataPostazioni",
                        principalColumn: "tpo_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbcl_utentePostazioni_tbcl_utenti_Upo_IDUtente",
                        column: x => x.Upo_IDUtente,
                        principalTable: "tbcl_utenti",
                        principalColumn: "Ute_IDAuto",
                        onDelete: ReferentialAction.Cascade);
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
                    DbUtenteUte_IDAuto = table.Column<int>(type: "int", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbco_SessioniEasyGold", x => x.Sse_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbco_SessioniEasyGold_tbcl_utenti_DbUtenteUte_IDAuto",
                        column: x => x.DbUtenteUte_IDAuto,
                        principalTable: "tbcl_utenti",
                        principalColumn: "Ute_IDAuto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_fiscalePostazioni_Fpo_IDPostazione",
                table: "tbcl_fiscalePostazioni",
                column: "Fpo_IDPostazione");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_fiscalePostazioni_Fpo_IDRegFiscale",
                table: "tbcl_fiscalePostazioni",
                column: "Fpo_IDRegFiscale");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_gruppi_lang_DbGruppiGrp_IDAuto",
                table: "tbcl_gruppi_lang",
                column: "DbGruppiGrp_IDAuto");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_gruppi_lang_grpid_ID",
                table: "tbcl_gruppi_lang",
                column: "grpid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_lettorePostazioni_Lpo_IDPostazione",
                table: "tbcl_lettorePostazioni",
                column: "Lpo_IDPostazione");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_PermessiGruppo_Abg_IDFunzione",
                table: "tbcl_PermessiGruppo",
                column: "Abg_IDFunzione");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_PermessiGruppo_Abg_IDGruppo",
                table: "tbcl_PermessiGruppo",
                column: "Abg_IDGruppo");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_PermessiGruppo_DbTipoPermessoTpa_IDAuto",
                table: "tbcl_PermessiGruppo",
                column: "DbTipoPermessoTpa_IDAuto");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_pwUtenti_Utp_IDUtente",
                table: "tbcl_pwUtenti",
                column: "Utp_IDUtente");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_pwUtenti_Utp_TipoPw",
                table: "tbcl_pwUtenti",
                column: "Utp_TipoPw");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_refresh_token_UserId",
                table: "tbcl_refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_regFiscale_Rfi_CodNegozio",
                table: "tbcl_regFiscale",
                column: "Rfi_CodNegozio");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_stampePostazioni_Tpo_IDPostazione",
                table: "tbcl_stampePostazioni",
                column: "Tpo_IDPostazione");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_stampePostazioni_Tpo_IDStampa",
                table: "tbcl_stampePostazioni",
                column: "Tpo_IDStampa");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_utenteNegozi_Utn_IDNegozio",
                table: "tbcl_utenteNegozi",
                column: "Utn_IDNegozio");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_utenteNegozi_Utn_IDUtente",
                table: "tbcl_utenteNegozi",
                column: "Utn_IDUtente");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_utentePostazioni_Upo_IDNegozio",
                table: "tbcl_utentePostazioni",
                column: "Upo_IDNegozio");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_utentePostazioni_Upo_IDPostazione",
                table: "tbcl_utentePostazioni",
                column: "Upo_IDPostazione");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_utentePostazioni_Upo_IDUtente",
                table: "tbcl_utentePostazioni",
                column: "Upo_IDUtente");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_utenti_Ute_IDGruppo",
                table: "tbcl_utenti",
                column: "Ute_IDGruppo");

            migrationBuilder.CreateIndex(
                name: "IX_tbco_SessioniEasyGold_DbUtenteUte_IDAuto",
                table: "tbco_SessioniEasyGold",
                column: "DbUtenteUte_IDAuto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "tbcl_fiscalePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_gruppi_lang");

            migrationBuilder.DropTable(
                name: "tbcl_lettorePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_nazioneNegozio");

            migrationBuilder.DropTable(
                name: "tbcl_negoziAltro");

            migrationBuilder.DropTable(
                name: "tbcl_PermessiGruppo");

            migrationBuilder.DropTable(
                name: "tbcl_pwUtenti");

            migrationBuilder.DropTable(
                name: "tbcl_refresh_token");

            migrationBuilder.DropTable(
                name: "tbcl_stampePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_tipopw_Lang");

            migrationBuilder.DropTable(
                name: "tbcl_utenteNegozi");

            migrationBuilder.DropTable(
                name: "tbcl_utentePostazioni");

            migrationBuilder.DropTable(
                name: "tbco_funzioni_lang");

            migrationBuilder.DropTable(
                name: "tbco_SessioniEasyGold");

            migrationBuilder.DropTable(
                name: "tbco_testataPostazioni_lang");

            migrationBuilder.DropTable(
                name: "tbco_tipoPermesso_lang");

            migrationBuilder.DropTable(
                name: "tbcl_regFiscale");

            migrationBuilder.DropTable(
                name: "tbco_tipoPermesso");

            migrationBuilder.DropTable(
                name: "tbcl_tipoPw");

            migrationBuilder.DropTable(
                name: "tbco_moduliStampe");

            migrationBuilder.DropTable(
                name: "tbcl_testataPostazioni");

            migrationBuilder.DropTable(
                name: "tbco_funzioni");

            migrationBuilder.DropTable(
                name: "tbcl_utenti");

            migrationBuilder.DropTable(
                name: "Negozi");

            migrationBuilder.DropTable(
                name: "tbcl_gruppi");
        }
    }
}
