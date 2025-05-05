using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class NomeMigrazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbco_ValoriTabelle");
        }
    }
}
