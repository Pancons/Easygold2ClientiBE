using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class TabellaStatiCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utw_Blocco",
                table: "Clienti");

            migrationBuilder.AddColumn<int>(
                name: "Utw_IdStatoCliente",
                table: "Clienti",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StatiCliente",
                columns: table => new
                {
                    Stc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stc_Descrizione = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatiCliente", x => x.Stc_id);
                });

            migrationBuilder.InsertData(
                table: "StatiCliente",
                columns: new[] { "Stc_id", "Stc_Descrizione" },
                values: new object[,]
                {
                    {1, "Attivo"},
                    {2, "Bloccato"},
                    {3, "Sospeso"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatiCliente");

            migrationBuilder.DropColumn(
                name: "Utw_IdStatoCliente",
                table: "Clienti");

            migrationBuilder.AddColumn<bool>(
                name: "Utw_Blocco",
                table: "Clienti",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
