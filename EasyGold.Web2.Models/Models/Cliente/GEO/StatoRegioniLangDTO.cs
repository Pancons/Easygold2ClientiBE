using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.GEO
{
    /// <summary>
    /// DTO per la traduzione Stato/Regione.
    /// </summary>
    public class StatoRegioniLangDto
    {
        [Required]
        public int StridISONum { get; set; } // Codice ISO lingua

        [Required]
        public int StridID { get; set; } // ID record principale

        [Required, StringLength(200)]
        public string StridDescrizione { get; set; } // Descrizione tradotta
    }
}