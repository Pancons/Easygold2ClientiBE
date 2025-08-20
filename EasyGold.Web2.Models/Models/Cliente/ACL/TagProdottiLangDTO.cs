using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Tag Prodotti Lingua.
    /// </summary>
    public class TagProdottiLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua di traduzione.")]
        public int EtpId_ISONum { get; set; }

        [SwaggerSchema(Description = "ID dell'etichetta del prodotto associato.")]
        public int EtpId_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione dell'etichetta tradotta.")]
        [StringLength(100)]
        public string EtpId_Descrizione { get; set; }
    }
}