using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class ModuliStampeDTO
    {
        [SwaggerSchema(Description = "ID Automatico.")]
        public int Mst_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del Modulo di Stampa.")]
        [StringLength(100)]
        public string Mst_Descrizione { get; set; }

        [SwaggerSchema(Description = "Nome del Modulo di Stampa.")]
        [StringLength(50)]
        public string Mst_NomeModulo { get; set; }

        [SwaggerSchema(Description = "Tipo del Modulo.")]
        public int Mst_TipoModulo { get; set; }

        [SwaggerSchema(Description = "Indica se il record è annullato.")]
        public bool Mst_Annullato { get; set; }
    }
}