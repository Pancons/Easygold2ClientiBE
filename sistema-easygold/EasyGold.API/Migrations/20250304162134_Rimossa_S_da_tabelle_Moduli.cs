using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class Rimossa_S_da_tabelle_Moduli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloEasygolds",
                table: "ModuloEasygolds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloEasygoldLangs",
                table: "ModuloEasygoldLangs");

            migrationBuilder.RenameTable(
                name: "ModuloEasygolds",
                newName: "ModuloEasygold");

            migrationBuilder.RenameTable(
                name: "ModuloEasygoldLangs",
                newName: "ModuloEasygoldLang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloEasygold",
                table: "ModuloEasygold",
                column: "Mde_IDAuto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloEasygoldLang",
                table: "ModuloEasygoldLang",
                column: "Mdeid_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloEasygoldLang",
                table: "ModuloEasygoldLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuloEasygold",
                table: "ModuloEasygold");

            migrationBuilder.RenameTable(
                name: "ModuloEasygoldLang",
                newName: "ModuloEasygoldLangs");

            migrationBuilder.RenameTable(
                name: "ModuloEasygold",
                newName: "ModuloEasygolds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloEasygoldLangs",
                table: "ModuloEasygoldLangs",
                column: "Mdeid_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuloEasygolds",
                table: "ModuloEasygolds",
                column: "Mde_IDAuto");
        }
    }
}
