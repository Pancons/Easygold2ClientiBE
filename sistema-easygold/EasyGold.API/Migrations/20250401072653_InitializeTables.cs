using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class InitializeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ruoli",
                columns: new[] { "Ur_IDRuolo", "Ur_Descrizione" },
                values: new object[,]
                {
                    {1, "Amministratori" }
                });

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Ute_IDUtente", "Ute_Nome", "Ute_Cognome", "Ute_NomeUtente", "Ute_IDRuolo", "Ute_Bloccato", "Ute_Nota", "Ute_Password" },
                values: new object[,]
                {
                    {1, "Amministratore", "", "admin", 1, false, "", BCrypt.Net.BCrypt.HashPassword("Abcd1234@") }
                });

            migrationBuilder.InsertData(
                table: "ModuloEasygold",
                columns: new[] { "Mde_IDAuto", "Mde_CodEcomm", "Mde_Descrizione", "Mde_DescrizioneEstesa" },
                values: new object[,]
                {
                    {1, "Gestione C/Vendita Fornitore", "Gestione C/Vendita Fornitore", "Permette la gestione completa dei prodotti che riceviamo in C/Vendita dal Fornitore. Inserirli in magazzino, Venderli, Acquistarli e/o renderli al Fornitore."},
                    {2, "Fidelity e Gift Card", "Fidelity e Gift Card", "Permette la gestione delle card sia Fidelity che Gift Card. L'inizializzazione e la gestione delle singole Gift Card con la ricarica e il pagamento e la lista di tutti i movimenti fatti. Per la Fidelity invece associazione della card al singolo Cliente."},
                    {3, "Fatturazione Elettronica Completa", "Fatturazione Elettronica Completa", "Permette la gestione delle Fatture Attive emesse e delle Fatture Passive. Genera per le Fatture Attive il file XML e gestisce l’invio allo SDI."},
                    {4, "Fatturazione Elettronica Solo Attiva", "Fatturazione Elettronica Solo Attiva", "Permette la gestione delle Fatture Attive emesse generando il file XML e l’invio allo SDI. NON gestisce le Fatture Passive."},
                    {5, "Gestione C/Vendita Cliente", "Gestione C/Vendita Cliente", "Permette la gestione completa dei prodotti che inviamo in C/Vendita ai Clienti. Inviarli al Cliente, Venderli o eseguire il Reso da parte del Cliente."},
                    {6, "Distinta Base", "Distinta Base", "Attiva la gestione della Distinta Base durante il Carico di Magazzino."},
                    {7, "Metallo C/Lavorazione", "Metallo C/Lavorazione", "Per gestire la fusione del metallo o l’invio ad un Fornitore del metallo “da scontare” o “in Lavorazione”."},
                    {8, "API E-commerce", "API E-commerce", "Per interfacciare l’E-commerce del Cliente con Easygold PRO."},
                    {9, "Top Deals", "Top Deals", "Permette la gestione di campagne sconto nella funzione vendite per diversi parametri."},
                    {10, "CRM", "CRM", "Gestisce le informazioni estese dei Clienti e le relative campagne Marketing."},
                    {11, "Manifestazione di Interesse", "Manifestazione di Interesse", "Gestisce le proposte di vendita dei Clienti."},
                    {12, "Trigger", "Trigger", "Gestisce la possibilità di far fare azioni ripetute quando viene eseguita una determinata funzione."},
                    {13, "My Brand", "My Brand", "Gestisce un Brand proprio con il ricevimento degli ordini da parte dei “Concessionari”."}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Utenti",
                keyColumn: "Ute_IDUtente",
                keyValue: 1
                );
            migrationBuilder.DeleteData(
                table: "Ruoli",
                keyColumn: "Ur_IDRuolo",
                keyValue: 1
                );
            migrationBuilder.DeleteData(
                table: "ModuloEasygold",
                keyColumn: "Mde_IDAuto",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 }
                );
        }
    }
}
