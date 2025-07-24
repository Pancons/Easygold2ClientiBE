using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Tabella “Comune” dbo.tbco_moduliStampe
    /// Contiene le Stampe e i relativi nomi iniziali dei moduli Crystal Report.
    /// </summary>
    [Table("tbco_moduliStampe")]
    public class DbModuliStampe
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// Identificativo univoco del modulo di stampa.
        /// </summary>
        [Key]
        public int Mst_IDAuto { get; set; }

        /// <summary>
        /// Campo Alfa 100 Caratteri.
        /// È la descrizione del modulo di stampa.
        /// </summary>
        [StringLength(100)]
        public string Mst_Descrizione { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// È la parte iniziale del nome dei moduli “Cliente”. 
        /// Es. FatturaCliente_ sarà l’inizio di FatturaCliente_FatturaItalia.rpt.
        /// </summary>
        [StringLength(50)]
        public string Mst_NomeModulo { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni,
        /// usato come tipo del modulo di stampa.
        /// </summary>
        public int Mst_TipoModulo { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True il record non è attivo.
        /// </summary>
        public bool Mst_Annullato { get; set; }
    }
}
