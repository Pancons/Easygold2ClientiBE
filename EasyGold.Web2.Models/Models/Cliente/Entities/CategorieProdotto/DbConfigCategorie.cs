using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.CategorieProdotto
{
    [Table("tbcl_configCategorie")]
    public class DbConfigCategorie : BaseDbEntity
    {
        /// <summary>
        /// ID della Categoria associata alle configurazioni.
        /// </summary>
        public int Coc_IDAuto { get; set; }

        /// <summary>
        /// ID del Brand associato.
        /// </summary>
        public int? Coc_IDBrand { get; set; }

        /// <summary>
        /// ID del Tipo Prodotto associato.
        /// </summary>
        public int? Coc_IDTipoProdotto { get; set; }

        /// <summary>
        /// ID del Tipo Acquisto associato.
        /// </summary>
        public int? Coc_IDTipoAcquisto { get; set; }

        /// <summary>
        /// ID del Tipo Manifattura associato.
        /// </summary>
        public int? Coc_IDTipoManifattura { get; set; }

        /// <summary>
        /// ID del Tipo Vendita associato.
        /// </summary>
        public int? Coc_IDTipoVendita { get; set; }

        /// <summary>
        /// Se si richiede l'inserimento di Pietre Preziose.
        /// </summary>
        public bool Coc_PietrePreziose { get; set; }

        /// <summary>
        /// Se si richiede la gestione del Sottocodice.
        /// </summary>
        public bool Coc_Sottocodice { get; set; }

        /// <summary>
        /// Se il prodotto è a Peso Medio.
        /// </summary>
        public bool Coc_PesoMedio { get; set; }

        /// <summary>
        /// Se si richiede l'inserimento del Numero di Serie.
        /// </summary>
        public bool Coc_Serie { get; set; }

        /// <summary>
        /// ID SKU associato.
        /// </summary>
        public int? Coc_IDSku { get; set; }

        /// <summary>
        /// Riferimento alla Categoria.
        /// </summary>
        [ForeignKey("Coc_IDAuto")]
        public virtual DbCategorie Categoria { get; set; }
    }
}