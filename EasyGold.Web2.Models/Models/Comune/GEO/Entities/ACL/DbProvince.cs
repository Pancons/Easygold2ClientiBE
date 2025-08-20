using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_province")]
    public class DbProvince
    {
        /// <summary>
        /// Numero ISO 3166 1 della Nazione.
        /// </summary>
        public int Str_ISO1 { get; set; }

        /// <summary>
        /// Codice della Provincia.
        /// </summary>
        [Key]
        public int Str_IDAuto { get; set; }

        /// <summary>
        /// Nome della Provincia.
        /// </summary>
        [StringLength(200)]
        public string Str_Descrizione { get; set; }

        /// <summary>
        /// Sigla della Provincia sulla targa dell'automobile.
        /// </summary>
        [StringLength(20)]
        public string Str_SiglaTargaAuto { get; set; }

        /// <summary>
        /// Codice dello Stato/Regione a cui appartiene la Provincia.
        /// </summary>
        public int Str_CodStatoRegione { get; set; }

        /// <summary>
        /// Traduzioni della Provincia.
        /// </summary>
        public virtual ICollection<DbProvinceLang> ProvinceLang { get; set; } = new List<DbProvinceLang>();
    }
}