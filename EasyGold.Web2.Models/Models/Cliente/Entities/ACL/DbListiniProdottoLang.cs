using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGold.Web2.Models.Cliente.Entities.ACL
{
    [Table("tbcl_listiniProdotto_lang")]
    public class DbListiniProdottoLang
    {
        /// <summary>
        /// Campo Numerico Intero. È il codice ISO della lingua di cui sono stati tradotti i testi.
        /// </summary>
        [Key, Column(Order = 0)]
        public int Lisid_ISONum { get; set; }

        /// <summary>
        /// Campo Numerico Intero. È il numero del record della tabella principale di cui è stata fatta la traduzione.
        /// </summary>
        [Key, Column(Order = 1)]
        public int Lisid_ID { get; set; }

        /// <summary>
        /// Campo Testo 100 caratteri. È il testo tradotto nella lingua della Nazione.
        /// </summary>
        [StringLength(100)]
        public string Lisid_Descrizione { get; set; }

        /// <summary>
        /// Relazione con il Listino Prodotto principale.
        /// </summary>
        [ForeignKey("Lisid_ID")]
        public DbListiniProdotto ListinoProdotto { get; set; }
    }
}