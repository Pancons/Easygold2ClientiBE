using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class CreditCardDTO
    {
        [SwaggerSchema(Description = "Identificativo univoco della carta di pagamento")]
        public int Crc_IdAuto { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "Descrizione del pagamento elettronico")]
        public string Crc_Card { get; set; }

        [SwaggerSchema(Description = "Commissione in percentuale")]
        public decimal Crc_Fee { get; set; }

        [SwaggerSchema(Description = "Ordine di visualizzazione")]
        public int Crc_Ordinamento { get; set; }

        [SwaggerSchema(Description = "Indica se la carta è annullata")]
        public bool Crc_Annulla { get; set; }
    }
}