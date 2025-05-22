using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ConfigProdotto
{
    public class PietraPreziosaDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco della pietra preziosa")]
        public int Ppz_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione della pietra")]
        public string Ppz_Pietra { get; set; }

        [SwaggerSchema(Description = "Indica se la pietra è un diamante")]
        public bool Ppz_Diamante { get; set; }

        [SwaggerSchema(Description = "Indica se la pietra è annullata")]
        public bool Ppz_Annulla { get; set; }
    }
}