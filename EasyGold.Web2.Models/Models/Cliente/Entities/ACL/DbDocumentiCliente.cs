using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    /// <summary>
    /// Tabella “Cliente” dbo.tbcl_documentiCliente
    /// Gestione dei documenti accettati per ciascun cliente.
    /// </summary>
    [Table("tbcl_documentiCliente")]
    public class DbDocumentiCliente
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Doc_IDAuto { get; set; }

        /// <summary>
        /// Codice ISO della nazione del Cliente.
        /// </summary>
        public int Doc_ISONum { get; set; }

        /// <summary>
        /// Documento accettato.
        /// </summary>
        [StringLength(100)]
        public string Doc_Documento { get; set; }

        /// <summary>
        /// Validità in anni del documento.
        /// </summary>
        public int Doc_ValidoAnni { get; set; }

        /// <summary>
        /// Indica se il documento è annullato.
        /// </summary>
        public bool Doc_Annulla { get; set; }
    }
}