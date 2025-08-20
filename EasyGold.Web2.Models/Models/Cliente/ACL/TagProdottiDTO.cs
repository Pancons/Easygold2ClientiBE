using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TagProdottiDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale dell'etichetta del prodotto.")]
        public int Etp_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione dell'etichetta del prodotto.")]
        [StringLength(100)]
        public string Etp_Descrizione { get; set; }

        [SwaggerSchema(Description = "ID del gruppo associato all'etichetta.")]
        public int Etp_Gruppo { get; set; }

        [SwaggerSchema(Description = "Colore della scritta dell'etichetta.")]
        [StringLength(16)]
        public string Etp_ColEtichetta { get; set; }

        [SwaggerSchema(Description = "Colore di sfondo dell'etichetta.")]
        [StringLength(16)]
        public string Etp_ColSfondo { get; set; }

        [SwaggerSchema(Description = "Tipo di etichetta.")]
        public int Etp_TipoEtichetta { get; set; }

        [SwaggerSchema(Description = "Data di scadenza dell'etichetta.")]
        public DateTime? Etp_DataScadenza { get; set; }

        [SwaggerSchema(Description = "Indica se l'etichetta è in evidenza.")]
        public bool Etp_InEvidenza { get; set; }

        [SwaggerSchema(Description = "Indica se l'etichetta è annullata.")]
        public bool Etp_Annullato { get; set; }

        [SwaggerSchema(Description = "Lista di traduzioni per l'etichetta del prodotto.")]
        public List<TagProdottiLangDTO> Traduzioni { get; set; } = new List<TagProdottiLangDTO>();
    }
}