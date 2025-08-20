using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.Metalli
{
    [Table("tbcl_quotazioneMetalli")]
    public class DbQuotazioneMetalli
    {
        /// <summary>
        /// Campo Numerico Intero Auto.
        /// </summary>
        [Key]
        public int Mqt_IDAuto { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il campo Met_IDAuto della tabella metalli.
        /// </summary>
        public int Mqt_ID { get; set; }

        /// <summary>
        /// Campo Money. Quotazione in acquisto del metallo.
        /// </summary>
        public decimal Mqt_Acquisto { get; set; }

        /// <summary>
        /// Campo Money. Quotazione in vendita del metallo fino.
        /// </summary>
        public decimal Mqt_VenditaFino { get; set; }
    }
}