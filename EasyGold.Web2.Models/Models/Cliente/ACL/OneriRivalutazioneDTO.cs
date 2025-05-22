using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class OneriRivalutazioneDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco dell'onere o rivalutazione")]
        public int Onr_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione del calcolo da eseguire nella colonna")]
        public string Onr_Modifica { get; set; }

        [SwaggerSchema(Description = "Percentuale di onere o rivalutazione")]
        public decimal Onr_Fee { get; set; }

        [SwaggerSchema(Description = "Ordine di visualizzazione")]
        public int Onr_Ordinamento { get; set; }

        [SwaggerSchema(Description = "Indica se l'onere o la rivalutazione è annullata")]
        public bool Onr_Annulla { get; set; }
    }
}