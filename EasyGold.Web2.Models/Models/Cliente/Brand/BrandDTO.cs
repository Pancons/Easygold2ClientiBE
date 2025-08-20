// Easygold2BE/EasyGold.Web2.Models/Models/Cliente/ACL/BrandDTO.cs

using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Brand
{
    /// <summary>
    /// DTO per Brand.
    /// </summary>
    public class BrandDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale del brand.")]
        public int Brd_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del Brand.")]
        [StringLength(100)]
        public string Brd_Brand { get; set; }

        [SwaggerSchema(Description = "Indica se il Brand è annullato.")]
        public bool Brd_Annulla { get; set; }

        [SwaggerSchema(Description = "Liste delle lingue del brand.")]
        public List<BrandLangDTO> Lingue { get; set; } = new List<BrandLangDTO>();
        
        [SwaggerSchema(Description = "Liste delle categorie del brand.")]
        public List<BrandCatDTO> Categorie { get; set; } = new List<BrandCatDTO>();
    }
}