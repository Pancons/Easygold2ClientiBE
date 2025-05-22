using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Prodotti
{
    public class CategorieDTO
    {
        [SwaggerSchema(Description = "Campo numero intero auto.")]
        public int Cat_IDAuto { get; set; }

        [SwaggerSchema(Description = "È l’IDAuto della stessa tabella dbo.tbcl_categorie della Categoria del livello subito superiore se ci troviamo ad un livello più basso. ")]
        public int Cat_IDPadre { get; set; }

        [SwaggerSchema(Description = "È la descrizione della Categoria.")]
        [StringLength(200)]
        public string Cat_DescCategoria { get; set; }

        [SwaggerSchema(Description = "Se è a True la Categoria è annullata. ")]
        public bool? Cat_Annulla { get; set; }
    }
}
