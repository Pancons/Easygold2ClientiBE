using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ListiniTabellaDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Lst_IDAuto { get; set; }

        [SwaggerSchema(Description = "È la descrizione del Listino di Vendita a Tabella.")]
        [StringLength(100)]
        public string Lst_Descrizione { get; set; }

        [SwaggerSchema(Description = "Tipo Calcolo Listino a Tabella.")]
        public int Lst_TipoCalcolo { get; set; }

        [SwaggerSchema(Description = "Campo money. Prezzo al Grammo per il tipo 1.")]
        public decimal Lst_PrezzoGrammo { get; set; }

        [SwaggerSchema(Description = "Moltiplicatore per il tipo 2 e 3.")]
        public decimal Lst_Moltiplicatore { get; set; }

        [SwaggerSchema(Description = "Moltiplicatore per il tipo 3 (per Manifattura).")]
        public decimal Lst_MoltipManifattura { get; set; }

        [SwaggerSchema(Description = "Se True, il valore è stato annullato.")]
        public bool Lst_Annullato { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate.")]
        public List<ListiniTabellaLangDTO> ListiniTabellaLang { get; set; } = new List<ListiniTabellaLangDTO>();
    }
}