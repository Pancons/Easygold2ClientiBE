using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class ListiniTabellaLangDTO
    {
        [SwaggerSchema(Description = "Codice ISO della lingua tradotta.")]
        public int Tbsid_ISONum { get; set; }

        [SwaggerSchema(Description = "Numero del record della tabella principale tradotto.")]
        public int Tbsid_ID { get; set; }

        [SwaggerSchema(Description = "Testo inserito dall’Utente tradotto nella lingua specificata.")]
        [StringLength(100)]
        public string Tbsid_Descrizione { get; set; }
    }
}