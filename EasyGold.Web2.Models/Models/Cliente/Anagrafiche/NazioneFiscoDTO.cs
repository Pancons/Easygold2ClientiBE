using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Anagrafiche
{
    public class NazioneFiscoDTO
    {
        /// <summary>
        /// Identificativo automatico della Nazione Fiscale.
        /// </summary>
        [SwaggerSchema(Description = "Identificativo automatico della Nazione Fiscale.")]
        public int Nfs_IDAuto { get; set; }

        /// <summary>
        /// Codice della Nazione, rappresenta il campo ISO1 nella tabella ISONazioni.
        /// </summary>
        [SwaggerSchema(Description = "Codice della Nazione, rappresenta il campo ISO1 nella tabella ISONazioni.")]
        public int Nfs_IDNazione { get; set; }

        /// <summary>
        /// Descrizione del campo richiesto.
        /// </summary>
        [SwaggerSchema(Description = "Descrizione del campo richiesto.")]
        [StringLength(100)]
        public string Nfs_Descrizione { get; set; }

        /// <summary>
        /// Tipo del campo (0 = Alfa, 1 = Numerico Intero, 2 = Numerico Decimale, 3 = Money, 4 = Campo di Ricerca).
        /// </summary>
        [SwaggerSchema(Description = "Tipo del campo (0 = Alfa, 1 = Numerico Intero, 2 = Numerico Decimale, 3 = Money, 4 = Campo di Ricerca).")]
        public int Nfs_TipoCampo { get; set; }

        /// <summary>
        /// Indica se il campo è obbligatorio.
        /// </summary>
        [SwaggerSchema(Description = "Indica se il campo è obbligatorio.")]
        public bool Nfs_Obbligatorio { get; set; }

        // Aggiungi proprietà di navigazione o relazioni qui, se necessario.
        // Esempio di relazione con un altro DTO (placeholder):
        // [SwaggerSchema(Description = "Descrizione di esempio per una relazione.")]
        // public List<RelatedEntityDTO> RelatedEntities { get; set; } = new List<RelatedEntityDTO>();
    }
}