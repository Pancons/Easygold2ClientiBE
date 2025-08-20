using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Carte di Pagamento.
    /// </summary>
    public class CreditCardDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale della carta di credito.")]
        public int Crc_IDAuto { get; set; }

        [SwaggerSchema(Description = "Descrizione del Pagamento Elettronico.")]
        [StringLength(100)]
        public string Crc_Card { get; set; }

        [SwaggerSchema(Description = "Commissione in percentuale.")]
        public decimal Crc_Fee { get; set; }

        [SwaggerSchema(Description = "Ordinamento della carta di pagamento.")]
        public int Crc_Ordinamento { get; set; }

        [SwaggerSchema(Description = "Indica se la carta di pagamento è annullata.")]
        public bool Crc_Annulla { get; set; }

        [SwaggerSchema(Description = "Liste delle traduzioni della carta di pagamento.")]
        public List<CreditCardLangDTO> Lingue { get; set; } = new List<CreditCardLangDTO>();
    }
}