using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TestataPostazioniLangDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero. È il codice ISO della lingua di cui sono stati tradotti i testi. Tabella dbo.tbco_idiomiEasygold campo idm_ISONum.")]
        public int tpoid_ISONum { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il numero del record della tabella principale di cui è stata fatta la traduzione.")]
        public int tpoid_ID { get; set; }

        [SwaggerSchema(Description = "Campo Testo 50 caratteri. È il nome della Postazione tradotto nella lingua della Nazione di cui al codice ISO.")]
        [StringLength(50)]
        public string tpoid_Descrizione { get; set; }
}
}
