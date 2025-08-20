using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{

    [Table("syscl_numeriRegIVA")]//
    
    public class DbNumeriRegIVA
    {
        /// <summary>
        /// Numero del record.
        /// </summary>
        [Key]
        public int RowIDAuto { get; set; }

        /// <summary>
        /// Codice del registro IVA.
        /// </summary>
        public int RowIDRegIVA { get; set; }

        /// <summary>
        /// Anno di riferimento per la fattura da emettere.
        /// </summary>
        public int NriAnno { get; set; }

        /// <summary>
        /// Numero dell'ultima fattura emessa.
        /// </summary>
        public int NriNumFattura { get; set; }

        /// <summary>
        /// Relazione con il registro IVA.
        /// </summary>
        [ForeignKey("RowIDRegIVA")]
        public DbRegIVA RegIVA { get; set; }
    }
}