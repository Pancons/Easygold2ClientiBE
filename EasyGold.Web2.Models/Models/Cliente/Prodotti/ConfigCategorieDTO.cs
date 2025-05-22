using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.Prodotti
{
    public class ConfigCategorieDTO
    {
        [SwaggerSchema(Description = "È il valore del campo cat_IDAuto della tabella dbo.tbcl_categorie.")]
        public int Coc_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il valore del campo brd_IDAuto della tabella dbo.tbcl_brand.")]
        public int? Coc_IDBrand { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Prodotto”. .")]
        public int? Coc_IDTipoProdotto { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Acquisto")]
        public int? coc_IDTipoAcquisto { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Manifattura")]
        public int? Coc_IDTipoManifattura { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Vendita")]
        public int? Coc_IDTipoVendita { get; set; }

        [SwaggerSchema(Description = "Se è True si richiede l’inserimento delle Pietre Preziose.")]
        public bool? Coc_PietrePreziose { get; set; }

        [SwaggerSchema(Description = "Se è True si richiede la gestione del Sottocodice.")]
        public bool? Coc_Sottocodice { get; set; }

        [SwaggerSchema(Description = "Se è True il prodotto è a Peso Medio.")]
        public bool? Coc_PesoMedio { get; set; }

        [SwaggerSchema(Description = "Se è True si richiede l’inserimento del Numero di Serie.")]
        public bool? Coc_Serie { get; set; }

        [SwaggerSchema(Description = "È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “SKU”.")]
        public bool? Coc_IDSku { get; set; }
    }
}
