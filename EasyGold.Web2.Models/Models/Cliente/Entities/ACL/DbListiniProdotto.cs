using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_listiniProdotto")]
    public class DbListiniProdotto
    {
        /// <summary>
        /// Campo Numerico Intero Auto. È il Listino di Vendita dei Prodotti.
        /// </summary>
        [Key]
        public int Lis_IDAuto { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. È la descrizione del Listino di Vendita.
        /// </summary>
        [StringLength(100)]
        public string Lis_Descrizione { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il valore del campo val_IDAuto della tabella dbo.tbcl_valute.
        /// </summary>
        public int Lis_Valuta { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni.
        /// </summary>
        public int Lis_TipoListino { get; set; }

        /// <summary>
        /// Campo bit. Indica se è il listino di default.
        /// </summary>
        public bool Lis_Default { get; set; }

        /// <summary>
        /// Campo Numerico Decimale. Percentuale di sconto applicata.
        /// </summary>
        public decimal Lis_PercSconto { get; set; }

        /// <summary>
        /// Campo Numerico Intero. Tipo di Arrotondamento.
        /// </summary>
        public int Lis_TipoArrotondamento { get; set; }

        /// <summary>
        /// Campo Money. Valore di Arrotondamento.
        /// </summary>
        public decimal Lis_Arrotondamento { get; set; }

        /// <summary>
        /// Campo bit. Indica se il listino è annullato.
        /// </summary>
        public bool Lis_Annullato { get; set; }

        /// <summary>
        /// Lista delle traduzioni associate al Listino.
        /// </summary>
        public virtual ICollection<DbListiniProdottoLang> ListiniProdottoLang { get; set; } = new List<DbListiniProdottoLang>();
    }
}