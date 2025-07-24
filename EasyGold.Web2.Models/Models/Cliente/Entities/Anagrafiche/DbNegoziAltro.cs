using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Anagrafiche
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_negoziAltro
    /// Contiene le configurazioni aggiuntive per i negozi, come nazione, valuta, listino e aliquota IVA.
    /// </summary>
    [Table("tbcl_negoziAltro")]
    public class DbNegoziAltro : BaseDbEntity
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// Identificativo univoco del record.
        /// </summary>
        [Key]
        public int Nea_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero Obbligatorio.
        /// Identifica la nazione associata al negozio.
        /// </summary>
        [Required]
        public int Nea_IDNazione { get; set; }

        /// <summary>
        /// Campo Numerico Intero Obbligatorio.
        /// Identifica la valuta associata al negozio.
        /// </summary>
        [Required]
        public int Nea_IDValuta { get; set; }

        /// <summary>
        /// Campo Numerico Intero Obbligatorio.
        /// Identifica il listino prezzi predefinito per il negozio.
        /// </summary>
        [Required]
        public int Nea_IDListino { get; set; }

        /// <summary>
        /// Campo Numerico Intero Obbligatorio.
        /// Identifica l’aliquota IVA predefinita applicata nel negozio.
        /// </summary>
        [Required]
        public int Nea_IDAliquotaIVA { get; set; }
    }
}
