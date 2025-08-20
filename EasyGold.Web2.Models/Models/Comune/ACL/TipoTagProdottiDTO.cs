using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    /// <summary>
    /// DTO per Tipo Tag Prodotti.
    /// </summary>
    public class TipoTagProdottiDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale del tipo di etichetta.")]
        public int Tpt_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del tipo di etichetta.")]
        [StringLength(100)]
        public string Tpt_Descrizione { get; set; }

        [SwaggerSchema(Description = "Tipo TAG associato.")]
        public int Tpt_TipoTag { get; set; }

        [SwaggerSchema(Description = "Numero di giorni di visibilità per l'etichetta.")]
        public int? Tpt_NumGiorni { get; set; }
    }
}