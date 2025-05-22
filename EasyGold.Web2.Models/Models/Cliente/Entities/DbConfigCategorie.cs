using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities
{

    [Table("tbcl_ConfigCategorie")]
    public class DbConfigCategorie : BaseDbEntity
    {
        /// <summary>
        /// È il valore del campo cat_IDAuto della tabella dbo.tbcl_categorie.
        /// </summary>
        [Key]
        public int Coc_IDAuto { get; set; }
        /// <summary>
        /// È il valore del campo brd_IDAuto della tabella dbo.tbcl_brand. 
        /// </summary>
        public int? Coc_IDBrand { get; set; }

        /// <summary>
        /// È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Prodotto”. 
        /// </summary>
        public int? Coc_IDTipoProdotto { get; set; }

        /// <summary>
        /// È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Acquisto”. 
        /// </summary>
        public int? coc_IDTipoAcquisto { get; set; }

        /// <summary>
        /// È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Manifattura”. 
        /// </summary>
        public int? Coc_IDTipoManifattura { get; set; }

        /// <summary>
        /// È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “Tipo Vendita”. 
        /// </summary>
        public int? Coc_IDTipoVendita { get; set; }

        /// <summary>
        /// Se è True si richiede l’inserimento delle Pietre Preziose.
        /// </summary>
        public bool? Coc_PietrePreziose { get; set; }

        /// <summary>
        /// Se è True si richiede la gestione del Sottocodice.
        /// </summary>
        public bool? Coc_Sottocodice { get; set; }
        /// <summary>
        /// Se è True il prodotto è a Peso Medio.
        /// </summary>
        public bool? Coc_PesoMedio { get; set; }

        /// <summary>
        /// Se è True si richiede l’inserimento del Numero di Serie.
        /// </summary>
        public bool? Coc_Serie {  get; set; }

        /// <summary>
        /// È il valore del campo tit_IDAuto della tabella dbo.tbco_tipoTabelle e il Tipo Tabella = “SKU”.
        /// </summary>
        public bool? Coc_IDSku { get; set; }
    }
}