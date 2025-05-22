using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TagProdottoDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco del tag prodotto")]
        public int Etp_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione dell'etichetta del prodotto")]
        public string Etp_Descrizione { get; set; }

        [StringLength(16)]
        [SwaggerSchema(Description = "Colore della scritta dell'etichetta")]
        public string Etp_ColEtichetta { get; set; }

        [StringLength(16)]
        [SwaggerSchema(Description = "Colore dello sfondo dell'etichetta")]
        public string Etp_ColSfondo { get; set; }

        [SwaggerSchema(Description = "Tipo di etichetta, riferisce a dbo.tbco_tipoTagProdotti")]
        public int Etp_TipoEtichetta { get; set; }

        [SwaggerSchema(Description = "Indica se il tag è visualizzato durante la vendita del prodotto")]
        public bool Etp_InEvidenza { get; set; }

        [SwaggerSchema(Description = "Indica se il tag è annullato")]
        public bool Etp_Annullato { get; set; }
    }
}