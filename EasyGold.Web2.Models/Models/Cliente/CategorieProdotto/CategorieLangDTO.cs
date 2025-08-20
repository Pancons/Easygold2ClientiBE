using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.CategorieProdotto
{
    public class CategorieLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua.")]
        public int Catid_ISONum { get; set; }

        [SwaggerSchema(Description = "ID della Categoria a cui è associata la traduzione.")]
        public int Catid_ID { get; set; }

        [SwaggerSchema(Description = "Descrizione tradotta della Categoria.")]
        [StringLength(100)]
        public string Catid_DescCategoria { get; set; }
    }
}