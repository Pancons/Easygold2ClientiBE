using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class TabellaValute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Valute",
                columns: new[] { "Val_id", "Val_Descrizione", "Val_Cambio", "Val_Simbolo", "Val_SimboloRegCassa", "Val_NumeroDecimali" },
                values: new object[,]
                {
                    {1, "Euro", 1, "€", "EUR", 2 },
                    {2, "Dollari", 1.33, "$", "USD", 2 },
                    {3, "Franchi Svizzeri", 1.2, "CHF", "CHF", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valute");
        }
    }
}
