using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Brand
{
    /// <summary>
    /// DTO per BrandCategoria.
    /// </summary>
    public class BrandCatDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale della categoria di brand.")]
        public int Brc_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID del brand associato.")]
        public int Brc_IDBrand { get; set; }

        [SwaggerSchema(Description = "ID della categoria associata.")]
        public int Brc_IDCategoria { get; set; }

        [SwaggerSchema(Description = "Indica se la categoria è annullata.")]
        public bool Brc_Annullato { get; set; }
    }
}