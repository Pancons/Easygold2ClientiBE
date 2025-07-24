using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyGold.Web2.Models.Cliente.Entities.Anagrafiche;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_regFiscale
    /// Contiene i registratori fiscali presenti nell’organizzazione.
    /// </summary>
    [Table("tbcl_regFiscale")]
    public class DbRegFiscale
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// Identificativo univoco del Registratore Fiscale.
        /// </summary>
        [Key]
        public int Rfi_IDAuto { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// È la descrizione del Registratore Fiscale.
        /// </summary>
        [StringLength(50)]
        public string Rfi_Descrizione { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il valore del campo tbc_IDAuto della tabella dbo.tbco_tabelleComuni,
        /// che rappresenta il tipo di Registratore Fiscale.
        /// </summary>
        public int Rfi_TipoRegFiscale { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il campo neg_IDAuto della tabella dbo.tbcl_negozi.
        /// Rappresenta il negozio a cui è associato il Registratore Fiscale.
        /// </summary>
        public int Rfi_CodNegozio { get; set; }

        /// <summary>
        /// Campo Alfa 50 Caratteri.
        /// È la matricola del Registratore Fiscale.
        /// Viene gestito automaticamente da Easygold quando si accede a funzioni che lo richiedono.
        /// </summary>
        [StringLength(50)]
        public string Rfi_Matricola { get; set; }

        /// <summary>
        /// Campo Numerico Intero.
        /// È il numero di chiusure effettuate dal Registratore Fiscale.
        /// È gestito automaticamente da Easygold.
        /// </summary>
        public int Rfi_NumeroChiusure { get; set; }

        /// <summary>
        /// Campo Data/Ora.
        /// È la data/ora dell’ultima chiusura eseguita sul Registratore Fiscale.
        /// </summary>
        public DateTime Rfi_UltimaDataChiusura { get; set; }

        /// <summary>
        /// Campo Bit.
        /// Se a True indica che il Registratore Fiscale non è più disponibile.
        /// </summary>
        public bool Rfi_Annullato { get; set; }

        /// <summary>
        /// Chiave esterna verso il negozio associato (dbo.tbcl_negozi).
        /// </summary>
        [ForeignKey("Rfi_CodNegozio")]
        public virtual DbNegozi Negozio { get; set; }
    }
}
