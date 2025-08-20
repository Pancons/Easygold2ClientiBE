using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per le traduzioni delle Imprese Finanziarie.
    /// </summary>
    public class ImpFinanziarieLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int Imfid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID dell'impresa finanziaria associata.")]
        public int Imfid_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta dell'impresa finanziaria.")]
        [StringLength(100)]
        public string Imfid_Descrizione { get; set; }
    }
}