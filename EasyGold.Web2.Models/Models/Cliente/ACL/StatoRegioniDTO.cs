using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.ACL
{
    /// <summary>
    /// DTO per Stato/Regione.
    /// </summary>
    public class StatoRegioniDto
    {
        [Required]
        public int StrIso1 { get; set; } // ISO 3166-1 della Nazione

        public int StrIdAuto { get; set; } // Codice Stato/Regione (PK)

        [Required, StringLength(200)]
        public string StrDescrizione { get; set; } // Stato/Nazione

        public int? StrCodCapoluogo { get; set; } // Codice Capoluogo (nullable)
    }
}