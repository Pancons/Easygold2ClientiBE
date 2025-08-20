using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.CategorieProdotto
{
    public class ConfigCategorieDTO
    {
        [SwaggerSchema(Description = "ID della Categoria associata alle configurazioni.")]
        public int Coc_IDAuto { get; set; }

        [SwaggerSchema(Description = "ID del Brand associato.")]
        public int? Coc_IDBrand { get; set; }

        [SwaggerSchema(Description = "ID del Tipo Prodotto associato.")]
        public int? Coc_IDTipoProdotto { get; set; }

        [SwaggerSchema(Description = "ID del Tipo Acquisto associato.")]
        public int? Coc_IDTipoAcquisto { get; set; }

        [SwaggerSchema(Description = "ID del Tipo Manifattura associato.")]
        public int? Coc_IDTipoManifattura { get; set; }

        [SwaggerSchema(Description = "ID del Tipo Vendita associato.")]
        public int? Coc_IDTipoVendita { get; set; }

        [SwaggerSchema(Description = "Se si richiede l'inserimento di Pietre Preziose.")]
        public bool Coc_PietrePreziose { get; set; }

        [SwaggerSchema(Description = "Se si richiede la gestione del Sottocodice.")]
        public bool Coc_Sottocodice { get; set; }

        [SwaggerSchema(Description = "Se il prodotto è a Peso Medio.")]
        public bool Coc_PesoMedio { get; set; }

        [SwaggerSchema(Description = "Se si richiede l'inserimento del Numero di Serie.")]
        public bool Coc_Serie { get; set; }

        [SwaggerSchema(Description = "ID SKU associato.")]
        public int? Coc_IDSku { get; set; }
    }
}