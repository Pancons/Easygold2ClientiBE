using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
namespace EasyGold.Web2.Models.Comune.Allegati
{
    public class AllegatoListRequest : BaseListRequest
    {
         /// <summary>
        /// Nome dell'entità a cui sono legati gli allegati (es. "Cliente", "Ordine", "Prodotto").
        /// </summary>
        [Required]
        [SwaggerSchema("Nome dell'entità di riferimento (es. 'Cliente', 'Ordine', 'Prodotto')")]
        public string EntitaRiferimento { get; set; }

        /// <summary>
        /// ID del record specifico per cui recuperare gli allegati.
        /// </summary>
        [Required]
        [SwaggerSchema("ID del record di riferimento")]
        public int RecordId { get; set; }

    }
}
