using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    /// <summary>
    /// Tabella “Comune” dbo.tbco_documentiFunzione
    /// Gestisce i documenti per le funzioni di Easygold per diverse nazioni.
    /// </summary>
    [Table("tbco_documentiFunzione")]
    public class DbDocumentiFunzione
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Dof_IDAuto { get; set; }

        /// <summary>
        /// Funzione associata (campo ad Albero a Scelta Singola).
        /// </summary>
        public int Dof_Funzione { get; set; }

        /// <summary>
        /// Codice ISO della nazione.
        /// </summary>
        public int Dof_ISONum { get; set; }

        /// <summary>
        /// Documento accettato.
        /// </summary>
        [StringLength(100)]
        public string Dof_Documento { get; set; }

        /// <summary>
        /// Tipo di documento (collegato alla tabella dbo.tbco_tabelleComuni).
        /// </summary>
        public int Dof_TipoDoc { get; set; }

        /// <summary>
        /// Sequenza di visualizzazione del documento.
        /// </summary>
        public int Dof_Sequenza { get; set; }

        /// <summary>
        /// Indica se il documento è annullato.
        /// </summary>
        public bool Dof_Annulla { get; set; }
        
    }
}