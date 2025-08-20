using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per la traduzione degli oneri e rivalutazioni.
    /// </summary>
    public class OneriRivalutazioniLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int OnrId_ISONum { get; set; }

        [SwaggerSchema(Description = "ID dell'onere o rivalutazione principale.")]
        public int OnrId_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta nella lingua specifica.")]
        [StringLength(100)]
        public string OnrId_Descrizione { get; set; }
    }
}