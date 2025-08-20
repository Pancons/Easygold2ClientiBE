using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EasyGold.Web2.Models.Comune.Entities.ACL
{
    [Table("tbco_idiomiEasygold")]
    public class DbIdiomiEasyGold : BaseDbEntity
    {
        /// <summary>
        /// Identificativo univoco per l'idioma.
        /// </summary>
        [Key]
        public int Idm_IDAuto { get; set; }
        
        /// <summary>
        /// Codice ISO della lingua.
        /// </summary>
        public int Idm_ISONum { get; set; }

    }
}