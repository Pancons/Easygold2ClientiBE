using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Oneri e Rivalutazioni.
    /// </summary>
    public class OneriRivalutazioniDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale dell'onere o rivalutazione.")]
        public int Onr_IDAuto { get; set; }

        [SwaggerSchema(Description = "Intestazione della colonna.")]
        [StringLength(100)]
        public string Onr_Modifica { get; set; }

        [SwaggerSchema(Description = "Percentuale di aumento o diminuzione.")]
        public decimal Onr_Fee { get; set; }

        [SwaggerSchema(Description = "Ordinamento della colonna.")]
        public int Onr_Ordinamento { get; set; }

        [SwaggerSchema(Description = "Indica se l'onere o rivalutazione è annullata.")]
        public bool Onr_Annulla { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni degli oneri e rivalutazioni.")]
        public List<OneriRivalutazioniLangDTO> Lingue { get; set; } = new List<OneriRivalutazioniLangDTO>();
    }
}