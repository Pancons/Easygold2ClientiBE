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
                name: "syscl_regIVA",
                columns: table => new
                {
                    RowIdAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RgiDescrizione = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RgiPrefisso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RgiSuffisso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RgiAnnulla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syscl_regIVA", x => x.RowIdAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_aliquoteIVA",
                columns: table => new
                {
                    Iva_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iva_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Iva_Aliquota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iva_Esenzione = table.Column<bool>(type: "bit", nullable: false),
                    Iva_Scorporata = table.Column<bool>(type: "bit", nullable: false),
                    Iva_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    Iva_Estero = table.Column<bool>(type: "bit", nullable: false),
                    Iva_NaturaFE = table.Column<int>(type: "int", nullable: false),
                    Iva_NaturaSC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_aliquoteIVA", x => x.Iva_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_brand",
                columns: table => new
                {
                    Brd_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brd_Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Brd_Annulla = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_brand", x => x.Brd_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_categorie",
                columns: table => new
                {
                    Cat_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_IDPadre = table.Column<int>(type: "int", nullable: true),
                    Cat_DescCategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cat_Annulla = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_categorie", x => x.Cat_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_causali",
                columns: table => new
                {
                    Cal_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cal_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cal_IDDoveUso = table.Column<int>(type: "int", nullable: false),
                    Cal_IDProgressivo = table.Column<int>(type: "int", nullable: false),
                    Cal_IDTipoAnagrafica = table.Column<int>(type: "int", nullable: false),
                    Cal_IDTipoIVA = table.Column<int>(type: "int", nullable: false),
                    Cal_Annulla = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_causali", x => x.Cal_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_codPagamento",
                columns: table => new
                {
                    Cpa_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpa_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpa_PartenzaMese = table.Column<int>(type: "int", nullable: false),
                    Cpa_NumMesi = table.Column<int>(type: "int", nullable: false),
                    Cpa_MeseCommerciale = table.Column<bool>(type: "bit", nullable: false),
                    Cpa_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_codPagamento", x => x.Cpa_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_creditCard",
                columns: table => new
                {
                    Crc_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crc_Card = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Crc_Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Crc_Ordinamento = table.Column<int>(type: "int", nullable: false),
                    Crc_Annulla = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_creditCard", x => x.Crc_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_documentiCliente",
                columns: table => new
                {
                    Doc_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doc_ISONum = table.Column<int>(type: "int", nullable: false),
                    Doc_Documento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Doc_ValidoAnni = table.Column<int>(type: "int", nullable: false),
                    Doc_Annulla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_documentiCliente", x => x.Doc_IDAuto);
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
                name: "tbcl_idiomiScelti",
                columns: table => new
                {
                    Idm_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idm_IDCliente = table.Column<int>(type: "int", nullable: false),
                    Idm_IDIdioma = table.Column<int>(type: "int", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_idiomiScelti", x => x.Idm_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_impFinanziarie",
                columns: table => new
                {
                    Imf_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imf_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Imf_IBAN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Imf_BIC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Imf_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_impFinanziarie", x => x.Imf_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_listiniProdotto",
                columns: table => new
                {
                    Lis_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lis_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lis_Valuta = table.Column<int>(type: "int", nullable: false),
                    Lis_TipoListino = table.Column<int>(type: "int", nullable: false),
                    Lis_Default = table.Column<bool>(type: "bit", nullable: false),
                    Lis_PercSconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lis_TipoArrotondamento = table.Column<int>(type: "int", nullable: false),
                    Lis_Arrotondamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lis_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_listiniProdotto", x => x.Lis_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_listiniTabella",
                columns: table => new
                {
                    Lst_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lst_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lst_TipoCalcolo = table.Column<int>(type: "int", nullable: false),
                    Lst_PrezzoGrammo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lst_Moltiplicatore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lst_MoltipManifattura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lst_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_listiniTabella", x => x.Lst_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_metalli",
                columns: table => new
                {
                    Met_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Met_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Met_Quotazione = table.Column<bool>(type: "bit", nullable: false),
                    Met_TipiMetallo = table.Column<bool>(type: "bit", nullable: false),
                    Met_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_metalli", x => x.Met_IDAuto);
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
                name: "tbcl_negozi",
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
                    table.PrimaryKey("PK_tbcl_negozi", x => x.Neg_id);
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
                name: "tbcl_oneriRivalutazioni",
                columns: table => new
                {
                    Onr_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Onr_Modifica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Onr_Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Onr_Ordinamento = table.Column<int>(type: "int", nullable: false),
                    Onr_Annulla = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_oneriRivalutazioni", x => x.Onr_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_tagProdotti",
                columns: table => new
                {
                    Etp_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etp_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Etp_Gruppo = table.Column<int>(type: "int", nullable: false),
                    Etp_ColEtichetta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Etp_ColSfondo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Etp_TipoEtichetta = table.Column<int>(type: "int", nullable: false),
                    Etp_DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Etp_InEvidenza = table.Column<bool>(type: "bit", nullable: false),
                    Etp_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tagProdotti", x => x.Etp_IDAuto);
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
                name: "tbcl_testataPostazioni_lang",
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
                    table.PrimaryKey("PK_tbcl_testataPostazioni_lang", x => new { x.tpoid_ISONum, x.tpoid_ID });
                });

            migrationBuilder.CreateTable(
                name: "tbcl_tipoPagamento",
                columns: table => new
                {
                    Tpg_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tpg_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tpg_Tipo = table.Column<int>(type: "int", nullable: false),
                    Tpg_Ordinamento = table.Column<int>(type: "int", nullable: false),
                    Tpg_Annulla = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipoPagamento", x => x.Tpg_IDAuto);
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
                name: "tbcl_tipoSKU",
                columns: table => new
                {
                    Sku_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku_TipoSKU = table.Column<int>(type: "int", nullable: false),
                    Sku_Valore = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sku_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipoSKU", x => x.Sku_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_valute",
                columns: table => new
                {
                    Val_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Val_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Val_Cambio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Val_NumDecimali = table.Column<int>(type: "int", nullable: false),
                    Val_SimboloValuta = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Val_SiglaValuta = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Val_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_valute", x => x.Val_IDAuto);
                });

            migrationBuilder.CreateTable(
                name: "syscl_config",
                columns: table => new
                {
                    Sys_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sys_Sezione = table.Column<int>(type: "int", nullable: false),
                    Sys_Nazione = table.Column<int>(type: "int", nullable: false),
                    Sys_NomeCampo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sys_TipoCampo = table.Column<int>(type: "int", nullable: false),
                    Sys_Valore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sys_Lunghezza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syscl_config", x => x.Sys_IDAuto);
                });
                
                

            migrationBuilder.CreateTable(
                name: "syscl_config_lag",
                columns: table => new
                {
                    Sysid_ISONum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sysid_ID = table.Column<int>(type: "int", nullable: false),
                    Sysid_NomeCampo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syscl_config_lag", x => x.Sysid_ISONum);
                    table.ForeignKey(
                        name: "FK_syscl_config_lag_syscl_config_Sysid_ID",
                        column: x => x.Sysid_ID,
                        principalTable: "syscl_config",
                        principalColumn: "Sys_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "syscl_numeriRegIVA",
                columns: table => new
                {
                    RowIDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowIDRegIVA = table.Column<int>(type: "int", nullable: false),
                    NriAnno = table.Column<int>(type: "int", nullable: false),
                    NriNumFattura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_syscl_numeriRegIVA", x => x.RowIDAuto);
                    table.ForeignKey(
                        name: "FK_syscl_numeriRegIVA_syscl_regIVA_RowIDRegIVA",
                        column: x => x.RowIDRegIVA,
                        principalTable: "syscl_regIVA",
                        principalColumn: "RowIdAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_aliquoteIVA_lang",
                columns: table => new
                {
                    Ivaid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Ivaid_ID = table.Column<int>(type: "int", nullable: false),
                    Ivaid_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_aliquoteIVA_lang", x => new { x.Ivaid_ISONum, x.Ivaid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_aliquoteIVA_lang_tbcl_aliquoteIVA_Ivaid_ID",
                        column: x => x.Ivaid_ID,
                        principalTable: "tbcl_aliquoteIVA",
                        principalColumn: "Iva_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_brand_lang",
                columns: table => new
                {
                    BrdId_ISONum = table.Column<int>(type: "int", nullable: false),
                    BrdId_ID = table.Column<int>(type: "int", nullable: false),
                    BrdId_Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_brand_lang", x => new { x.BrdId_ID, x.BrdId_ISONum });
                    table.ForeignKey(
                        name: "FK_tbcl_brand_lang_tbcl_brand_BrdId_ID",
                        column: x => x.BrdId_ID,
                        principalTable: "tbcl_brand",
                        principalColumn: "Brd_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_brandCat",
                columns: table => new
                {
                    Brc_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brc_IDBrand = table.Column<int>(type: "int", nullable: false),
                    Brc_IDCategoria = table.Column<int>(type: "int", nullable: false),
                    Brc_Annullato = table.Column<bool>(type: "bit", nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_brandCat", x => x.Brc_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_brandCat_tbcl_brand_Brc_IDBrand",
                        column: x => x.Brc_IDBrand,
                        principalTable: "tbcl_brand",
                        principalColumn: "Brd_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_categorie_lang",
                columns: table => new
                {
                    Catid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Catid_ID = table.Column<int>(type: "int", nullable: false),
                    Catid_DescCategoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_categorie_lang", x => new { x.Catid_ISONum, x.Catid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_categorie_lang_tbcl_categorie_Catid_ID",
                        column: x => x.Catid_ID,
                        principalTable: "tbcl_categorie",
                        principalColumn: "Cat_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_configCategorie",
                columns: table => new
                {
                    Coc_IDAuto = table.Column<int>(type: "int", nullable: false),
                    Coc_IDBrand = table.Column<int>(type: "int", nullable: true),
                    Coc_IDTipoProdotto = table.Column<int>(type: "int", nullable: true),
                    Coc_IDTipoAcquisto = table.Column<int>(type: "int", nullable: true),
                    Coc_IDTipoManifattura = table.Column<int>(type: "int", nullable: true),
                    Coc_IDTipoVendita = table.Column<int>(type: "int", nullable: true),
                    Coc_PietrePreziose = table.Column<bool>(type: "bit", nullable: false),
                    Coc_Sottocodice = table.Column<bool>(type: "bit", nullable: false),
                    Coc_PesoMedio = table.Column<bool>(type: "bit", nullable: false),
                    Coc_Serie = table.Column<bool>(type: "bit", nullable: false),
                    Coc_IDSku = table.Column<int>(type: "int", nullable: true),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_configCategorie", x => x.Coc_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_configCategorie_tbcl_categorie_Coc_IDAuto",
                        column: x => x.Coc_IDAuto,
                        principalTable: "tbcl_categorie",
                        principalColumn: "Cat_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_causali_lang",
                columns: table => new
                {
                    Cal_ISONum = table.Column<int>(type: "int", nullable: false),
                    Cal_ID = table.Column<int>(type: "int", nullable: false),
                    Cal_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cal_IDAuto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_causali_lang", x => new { x.Cal_ISONum, x.Cal_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_causali_lang_tbcl_causali_Cal_ID",
                        column: x => x.Cal_ID,
                        principalTable: "tbcl_causali",
                        principalColumn: "Cal_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_codPagamento_lang",
                columns: table => new
                {
                    CpaId_ISONum = table.Column<int>(type: "int", nullable: false),
                    CpaId_ID = table.Column<int>(type: "int", nullable: false),
                    CpaId_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_codPagamento_lang", x => new { x.CpaId_ID, x.CpaId_ISONum });
                    table.ForeignKey(
                        name: "FK_tbcl_codPagamento_lang_tbcl_codPagamento_CpaId_ID",
                        column: x => x.CpaId_ID,
                        principalTable: "tbcl_codPagamento",
                        principalColumn: "Cpa_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_creditCard_lang",
                columns: table => new
                {
                    CrcId_ISONum = table.Column<int>(type: "int", nullable: false),
                    CrcId_ID = table.Column<int>(type: "int", nullable: false),
                    CrcId_Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_creditCard_lang", x => new { x.CrcId_ID, x.CrcId_ISONum });
                    table.ForeignKey(
                        name: "FK_tbcl_creditCard_lang_tbcl_creditCard_CrcId_ID",
                        column: x => x.CrcId_ID,
                        principalTable: "tbcl_creditCard",
                        principalColumn: "Crc_IDAuto",
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
                name: "tbcl_PermessiGruppo",
                columns: table => new
                {
                    Abg_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abg_IDGruppo = table.Column<int>(type: "int", nullable: false),
                    Abg_IDFunzione = table.Column<int>(type: "int", nullable: false),
                    Abg_IDTipoPermesso = table.Column<int>(type: "int", nullable: false),
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
                name: "tbcl_impFinanziarie_lang",
                columns: table => new
                {
                    Imfid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Imfid_ID = table.Column<int>(type: "int", nullable: false),
                    Imfid_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_impFinanziarie_lang", x => new { x.Imfid_ISONum, x.Imfid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_impFinanziarie_lang_tbcl_impFinanziarie_Imfid_ID",
                        column: x => x.Imfid_ID,
                        principalTable: "tbcl_impFinanziarie",
                        principalColumn: "Imf_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_listiniProdotto_lang",
                columns: table => new
                {
                    Lisid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Lisid_ID = table.Column<int>(type: "int", nullable: false),
                    Lisid_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_listiniProdotto_lang", x => new { x.Lisid_ISONum, x.Lisid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_listiniProdotto_lang_tbcl_listiniProdotto_Lisid_ID",
                        column: x => x.Lisid_ID,
                        principalTable: "tbcl_listiniProdotto",
                        principalColumn: "Lis_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_listiniTabella_lang",
                columns: table => new
                {
                    Tbsid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Tbsid_ID = table.Column<int>(type: "int", nullable: false),
                    Tbsid_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_listiniTabella_lang", x => new { x.Tbsid_ISONum, x.Tbsid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_listiniTabella_lang_tbcl_listiniTabella_Tbsid_ID",
                        column: x => x.Tbsid_ID,
                        principalTable: "tbcl_listiniTabella",
                        principalColumn: "Lst_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_metalli_lang",
                columns: table => new
                {
                    MetID_ISONum = table.Column<int>(type: "int", nullable: false),
                    MetID_ID = table.Column<int>(type: "int", nullable: false),
                    MetID_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_metalli_lang", x => new { x.MetID_ISONum, x.MetID_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_metalli_lang_tbcl_metalli_MetID_ID",
                        column: x => x.MetID_ID,
                        principalTable: "tbcl_metalli",
                        principalColumn: "Met_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_quotazioneMetalli",
                columns: table => new
                {
                    Mqt_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mqt_ID = table.Column<int>(type: "int", nullable: false),
                    Mqt_Acquisto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mqt_VenditaFino = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_quotazioneMetalli", x => x.Mqt_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_quotazioneMetalli_tbcl_metalli_Mqt_ID",
                        column: x => x.Mqt_ID,
                        principalTable: "tbcl_metalli",
                        principalColumn: "Met_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_tipiMetallo",
                columns: table => new
                {
                    Tim_IDAuto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tim_ID = table.Column<int>(type: "int", nullable: false),
                    Tim_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tim_Annullato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipiMetallo", x => x.Tim_IDAuto);
                    table.ForeignKey(
                        name: "FK_tbcl_tipiMetallo_tbcl_metalli_Tim_ID",
                        column: x => x.Tim_ID,
                        principalTable: "tbcl_metalli",
                        principalColumn: "Met_IDAuto",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_tbcl_regFiscale_tbcl_negozi_Rfi_CodNegozio",
                        column: x => x.Rfi_CodNegozio,
                        principalTable: "tbcl_negozi",
                        principalColumn: "Neg_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_oneriRivalutazioni_lang",
                columns: table => new
                {
                    OnrId_ISONum = table.Column<int>(type: "int", nullable: false),
                    OnrId_ID = table.Column<int>(type: "int", nullable: false),
                    OnrId_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rowcreated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rowupdated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    rowdeleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_oneriRivalutazioni_lang", x => new { x.OnrId_ID, x.OnrId_ISONum });
                    table.ForeignKey(
                        name: "FK_tbcl_oneriRivalutazioni_lang_tbcl_oneriRivalutazioni_OnrId_ID",
                        column: x => x.OnrId_ID,
                        principalTable: "tbcl_oneriRivalutazioni",
                        principalColumn: "Onr_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_tagProdotti_lang",
                columns: table => new
                {
                    EtpId_ISONum = table.Column<int>(type: "int", nullable: false),
                    EtpId_ID = table.Column<int>(type: "int", nullable: false),
                    EtpId_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tagProdotti_lang", x => new { x.EtpId_ISONum, x.EtpId_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_tagProdotti_lang_tbcl_tagProdotti_EtpId_ID",
                        column: x => x.EtpId_ID,
                        principalTable: "tbcl_tagProdotti",
                        principalColumn: "Etp_IDAuto",
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
                name: "tbcl_tipoPagamento_lang",
                columns: table => new
                {
                    Tpgid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Tpgid_ID = table.Column<int>(type: "int", nullable: false),
                    Tpgid_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipoPagamento_lang", x => new { x.Tpgid_ISONum, x.Tpgid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_tipoPagamento_lang_tbcl_tipoPagamento_Tpgid_ID",
                        column: x => x.Tpgid_ID,
                        principalTable: "tbcl_tipoPagamento",
                        principalColumn: "Tpg_IDAuto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbcl_valute_lang",
                columns: table => new
                {
                    Valid_ISONum = table.Column<int>(type: "int", nullable: false),
                    Valid_ID = table.Column<int>(type: "int", nullable: false),
                    Valid_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_valute_lang", x => new { x.Valid_ISONum, x.Valid_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_valute_lang_tbcl_valute_Valid_ID",
                        column: x => x.Valid_ID,
                        principalTable: "tbcl_valute",
                        principalColumn: "Val_IDAuto",
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
                        name: "FK_tbcl_utenteNegozi_tbcl_negozi_Utn_IDNegozio",
                        column: x => x.Utn_IDNegozio,
                        principalTable: "tbcl_negozi",
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
                        name: "FK_tbcl_utentePostazioni_tbcl_negozi_Upo_IDNegozio",
                        column: x => x.Upo_IDNegozio,
                        principalTable: "tbcl_negozi",
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
                name: "tbcl_tipiMetallo_lang",
                columns: table => new
                {
                    TimID_ISONum = table.Column<int>(type: "int", nullable: false),
                    TimID_ID = table.Column<int>(type: "int", nullable: false),
                    TimID_Descrizione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbcl_tipiMetallo_lang", x => new { x.TimID_ISONum, x.TimID_ID });
                    table.ForeignKey(
                        name: "FK_tbcl_tipiMetallo_lang_tbcl_tipiMetallo_TimID_ID",
                        column: x => x.TimID_ID,
                        principalTable: "tbcl_tipiMetallo",
                        principalColumn: "Tim_IDAuto",
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

            
            migrationBuilder.CreateIndex(
                name: "IX_syscl_config_lag_Sysid_ID",
                table: "syscl_config_lag",
                column: "Sysid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_syscl_numeriRegIVA_RowIDRegIVA",
                table: "syscl_numeriRegIVA",
                column: "RowIDRegIVA");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_aliquoteIVA_lang_Ivaid_ID",
                table: "tbcl_aliquoteIVA_lang",
                column: "Ivaid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_brandCat_Brc_IDBrand",
                table: "tbcl_brandCat",
                column: "Brc_IDBrand");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_categorie_lang_Catid_ID",
                table: "tbcl_categorie_lang",
                column: "Catid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_causali_lang_Cal_ID",
                table: "tbcl_causali_lang",
                column: "Cal_ID");

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
                name: "IX_tbcl_impFinanziarie_lang_Imfid_ID",
                table: "tbcl_impFinanziarie_lang",
                column: "Imfid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_lettorePostazioni_Lpo_IDPostazione",
                table: "tbcl_lettorePostazioni",
                column: "Lpo_IDPostazione");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_listiniProdotto_lang_Lisid_ID",
                table: "tbcl_listiniProdotto_lang",
                column: "Lisid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_listiniTabella_lang_Tbsid_ID",
                table: "tbcl_listiniTabella_lang",
                column: "Tbsid_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_metalli_lang_MetID_ID",
                table: "tbcl_metalli_lang",
                column: "MetID_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_PermessiGruppo_Abg_IDGruppo",
                table: "tbcl_PermessiGruppo",
                column: "Abg_IDGruppo");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_pwUtenti_Utp_IDUtente",
                table: "tbcl_pwUtenti",
                column: "Utp_IDUtente");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_pwUtenti_Utp_TipoPw",
                table: "tbcl_pwUtenti",
                column: "Utp_TipoPw");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_quotazioneMetalli_Mqt_ID",
                table: "tbcl_quotazioneMetalli",
                column: "Mqt_ID");

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
                name: "IX_tbcl_tagProdotti_lang_EtpId_ID",
                table: "tbcl_tagProdotti_lang",
                column: "EtpId_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_tipiMetallo_Tim_ID",
                table: "tbcl_tipiMetallo",
                column: "Tim_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_tipiMetallo_lang_TimID_ID",
                table: "tbcl_tipiMetallo_lang",
                column: "TimID_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tbcl_tipoPagamento_lang_Tpgid_ID",
                table: "tbcl_tipoPagamento_lang",
                column: "Tpgid_ID");

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
                name: "IX_tbcl_valute_lang_Valid_ID",
                table: "tbcl_valute_lang",
                column: "Valid_ID");
        }
            

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "syscl_config_lag");

            migrationBuilder.DropTable(
                name: "syscl_numeriRegIVA");

            migrationBuilder.DropTable(
                name: "tbcl_aliquoteIVA_lang");

            migrationBuilder.DropTable(
                name: "tbcl_brand_lang");

            migrationBuilder.DropTable(
                name: "tbcl_brandCat");

            migrationBuilder.DropTable(
                name: "tbcl_categorie_lang");

            migrationBuilder.DropTable(
                name: "tbcl_causali_lang");

            migrationBuilder.DropTable(
                name: "tbcl_codPagamento_lang");

            migrationBuilder.DropTable(
                name: "tbcl_configCategorie");

            migrationBuilder.DropTable(
                name: "tbcl_creditCard_lang");

            migrationBuilder.DropTable(
                name: "tbcl_documentiCliente");

            migrationBuilder.DropTable(
                name: "tbcl_fiscalePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_gruppi_lang");

            migrationBuilder.DropTable(
                name: "tbcl_idiomiScelti");

            migrationBuilder.DropTable(
                name: "tbcl_impFinanziarie_lang");

            migrationBuilder.DropTable(
                name: "tbcl_lettorePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_listiniProdotto_lang");

            migrationBuilder.DropTable(
                name: "tbcl_listiniTabella_lang");

            migrationBuilder.DropTable(
                name: "tbcl_metalli_lang");

            migrationBuilder.DropTable(
                name: "tbcl_nazioneNegozio");

            migrationBuilder.DropTable(
                name: "tbcl_negoziAltro");

            migrationBuilder.DropTable(
                name: "tbcl_oneriRivalutazioni_lang");

            migrationBuilder.DropTable(
                name: "tbcl_PermessiGruppo");

            migrationBuilder.DropTable(
                name: "tbcl_pwUtenti");

            migrationBuilder.DropTable(
                name: "tbcl_quotazioneMetalli");

            migrationBuilder.DropTable(
                name: "tbcl_refresh_token");

            migrationBuilder.DropTable(
                name: "tbcl_stampePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_tagProdotti_lang");

            migrationBuilder.DropTable(
                name: "tbcl_testataPostazioni_lang");

            migrationBuilder.DropTable(
                name: "tbcl_tipiMetallo_lang");

            migrationBuilder.DropTable(
                name: "tbcl_tipoPagamento_lang");

            migrationBuilder.DropTable(
                name: "tbcl_tipopw_Lang");

            migrationBuilder.DropTable(
                name: "tbcl_tipoSKU");

            migrationBuilder.DropTable(
                name: "tbcl_utenteNegozi");

            migrationBuilder.DropTable(
                name: "tbcl_utentePostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_valute_lang");

            

            migrationBuilder.DropTable(
                name: "syscl_config");

            migrationBuilder.DropTable(
                name: "syscl_regIVA");

            migrationBuilder.DropTable(
                name: "tbcl_aliquoteIVA");

            migrationBuilder.DropTable(
                name: "tbcl_brand");

            migrationBuilder.DropTable(
                name: "tbcl_causali");

            migrationBuilder.DropTable(
                name: "tbcl_codPagamento");

            migrationBuilder.DropTable(
                name: "tbcl_categorie");

            migrationBuilder.DropTable(
                name: "tbcl_creditCard");

            migrationBuilder.DropTable(
                name: "tbcl_regFiscale");

            migrationBuilder.DropTable(
                name: "tbcl_impFinanziarie");

            migrationBuilder.DropTable(
                name: "tbcl_listiniProdotto");

            migrationBuilder.DropTable(
                name: "tbcl_listiniTabella");

            migrationBuilder.DropTable(
                name: "tbcl_oneriRivalutazioni");

            migrationBuilder.DropTable(
                name: "tbcl_tipoPw");

            migrationBuilder.DropTable(
                name: "tbcl_tagProdotti");

            migrationBuilder.DropTable(
                name: "tbcl_tipiMetallo");

            migrationBuilder.DropTable(
                name: "tbcl_tipoPagamento");

            migrationBuilder.DropTable(
                name: "tbcl_testataPostazioni");

            migrationBuilder.DropTable(
                name: "tbcl_utenti");

            migrationBuilder.DropTable(
                name: "tbcl_valute");

            migrationBuilder.DropTable(
                name: "tbcl_negozi");

            migrationBuilder.DropTable(
                name: "tbcl_metalli");

            migrationBuilder.DropTable(
                name: "tbcl_gruppi");
        }
    }
}
