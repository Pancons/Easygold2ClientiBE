using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.CategorieProdotto
{
    public class CategorieDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Cat_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID della Categoria del livello superiore, se applicabile.")]
        public int? Cat_IDPadre { get; set; }

        [SwaggerSchema(Description = "Descrizione della Categoria.")]
        [StringLength(100)]
        public string Cat_DescCategoria { get; set; }

        [SwaggerSchema(Description = "Se la Categoria è annullata.")]
        public bool Cat_Annulla { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate alla categoria.")]
        public List<CategorieLangDTO> CategorieLang { get; set; } = new List<CategorieLangDTO>();
    }
}