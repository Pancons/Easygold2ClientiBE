using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Comune.GEO.Entities.ACL
{
    [Table("tbco_ISONazioni")]
    public class DbISONazioni
    {
        /// <summary>
        /// Numero ISO 3166 1 della Nazione.
        /// </summary>
        [Key]
        public int Ntn_ISO1 { get; set; }

        /// <summary>
        /// Nome della Nazione.
        /// </summary>
        [StringLength(200)]
        public string Ntn_Descrizione { get; set; }

        /// <summary>
        /// Sigla ISO 3166-1 Alfa-2 della Nazione.
        /// </summary>
        [StringLength(2)]
        public string Ntn_ISO1A2 { get; set; }

        /// <summary>
        /// Sigla ISO 3166-1 Alfa-3 della Nazione.
        /// </summary>
        [StringLength(3)]
        public string Ntn_ISO1A3 { get; set; }

        /// <summary>
        /// Prefisso telefonico internazionale della Nazione.
        /// </summary>
        [StringLength(10)]
        public string Ntn_PrefTelef { get; set; }

        /// <summary>
        /// ID della tabella "Continenti".
        /// </summary>
        public int Ntn_Continente { get; set; }

        /// <summary>
        /// ID della tabella "Continenti" legale.
        /// </summary>
        public int Ntn_ContinenteLegale { get; set; }

        /// <summary>
        /// Numero ISO 3166 1 della Nazione a cui appartiene il territorio.
        /// </summary>
        public int Ntn_Appartiene { get; set; }

        /// <summary>
        /// Capitale De Iure della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Ntn_Capitale { get; set; }

        /// <summary>
        /// Capitale De Facto della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Ntn_CapitaleDeFacto { get; set; }

        /// <summary>
        /// Capitale Amministrativa della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Ntn_CapitaleAmm { get; set; }

        /// <summary>
        /// Capitale nella lingua originale della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Ntn_CapitaleIdioma { get; set; }

        /// <summary>
        /// Codice della valuta.
        /// </summary>
        public int Ntn_IDValuta { get; set; }

        /// <summary>
        /// Lunghezza del CAP della Nazione.
        /// </summary>
        public int Ntn_LunghezzaCAP { get; set; }

        /// <summary>
        /// Nome della Partita IVA.
        /// </summary>
        [StringLength(50)]
        public string Ntn_NomePI { get; set; }

        /// <summary>
        /// Tipo di Partita IVA.
        /// </summary>
        public int Ntn_TipoPI { get; set; }

        /// <summary>
        /// Lunghezza del campo Partita IVA.
        /// </summary>
        public int Ntn_LunghezzaPI { get; set; }

        /// <summary>
        /// Nome del Codice Fiscale.
        /// </summary>
        [StringLength(50)]
        public string Ntn_NomeCF { get; set; }

        /// <summary>
        /// Tipo del Codice Fiscale.
        /// </summary>
        public int Ntn_TipoCF { get; set; }

        /// <summary>
        /// Lunghezza Codice Fiscale.
        /// </summary>
        public int Ntn_LunghezzaCF { get; set; }

        /// <summary>
        /// Descrizione Stato/Regione.
        /// </summary>
        [StringLength(100)]
        public string Ntn_DescStatoRegione { get; set; }

        /// <summary>
        /// Stati/Regioni presenti.
        /// </summary>
        public bool Ntn_StatoRegione { get; set; }

        /// <summary>
        /// Lunghezza Sigla Provincia.
        /// </summary>
        public int Ntn_LungSiglaProv { get; set; }

        /// <summary>
        /// Province presenti.
        /// </summary>
        public bool Ntn_ProvSiNo { get; set; }

        /// <summary>
        /// Province nella tabella.
        /// </summary>
        public bool Ntn_Province { get; set; }

        /// <summary>
        /// Località presenti.
        /// </summary>
        public bool Ntn_Localita { get; set; }

        /// <summary>
        /// Indirizzi presenti.
        /// </summary>
        public bool Ntn_Indirizzi { get; set; }

        public virtual ICollection<DbIdISONazioni> IdISONazioniLang { get; set; } = new List<DbIdISONazioni>();
    }
}