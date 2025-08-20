using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ListiniProdottoDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto. È il Listino di Vendita dei Prodotti.")]
        public int Lis_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Testo 100 caratteri. È la descrizione del Listino di Vendita.")]
        [StringLength(100)]
        public string Lis_Descrizione { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il valore del campo val_IDAuto della tabella dbo.tbcl_valute.")]
        public int Lis_Valuta { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni.")]
        public int Lis_TipoListino { get; set; }

        [SwaggerSchema(Description = "Campo bit. Indica se è il listino di default.")]
        public bool Lis_Default { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Decimale. Percentuale di sconto applicata.")]
        public decimal Lis_PercSconto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. Tipo di Arrotondamento.")]
        public int Lis_TipoArrotondamento { get; set; }

        [SwaggerSchema(Description = "Campo Money. Valore di Arrotondamento.")]
        //[Column(TypeName = "money")]
        public decimal Lis_Arrotondamento { get; set; }

        [SwaggerSchema(Description = "Campo bit. Indica se il listino è annullato.")]
        public bool Lis_Annullato { get; set; }

        [SwaggerSchema(Description = "Lista delle traduzioni associate al Listino.")]
        public List<ListiniProdottoLangDTO> ListiniProdottoLang { get; set; } = new List<ListiniProdottoLangDTO>();
    }
}