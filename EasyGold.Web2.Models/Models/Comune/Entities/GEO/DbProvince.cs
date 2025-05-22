using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.Entities.GEO
{
    /// <summary>
    /// Entità per la tabella dbo.tbco_province (Province).
    /// </summary>
    [Table("tbco_province")]
    public class DbProvince : BaseDbEntity
    {
        /// <summary>
        /// Numero ISO 3166-1 della Nazione (ntn_ISO1).
        /// </summary>
        [Required]
        public int StrIso1 { get; set; }

        /// <summary>
        /// Codice Provincia (PK).
        /// </summary>
        [Key]
        public int StrIdAuto { get; set; }

        /// <summary>
        /// Nome della Provincia.
        /// </summary>
        [StringLength(200)]
        public string StrDescrizione { get; set; }

        /// <summary>
        /// Sigla della Provincia sulla targa dell’automobile.
        /// </summary>
        [StringLength(20)]
        public string StrSiglaTargaAuto { get; set; }

        /// <summary>
        /// Codice dello Stato/Regione a cui appartiene la Provincia.
        /// </summary>
        public int StrCodStatoRegione { get; set; }
    }
}