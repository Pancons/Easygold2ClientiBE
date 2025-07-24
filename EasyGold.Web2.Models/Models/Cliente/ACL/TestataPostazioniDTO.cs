using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class TestataPostazioniDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int tpo_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Alfa di 50 caratteri. È la descrizione della postazione.")]
        [StringLength(50)]
        public string tpo_descizione { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Se a True la postazione ha accesso al Registratore Fiscale. È selezionata a True in automatico quando viene inserito un record sulla tabella relativa. Deve essere riportato a False se poi il record in tabella viene cancellato.")]
        public bool tpo_registratore { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Se a True la postazione ha accesso alle Stampanti. È selezionata a True in automatico quando viene inserito un record sulla tabella relativa. Deve essere riportato a False se poi il record in tabella viene cancellato.")]
        public bool tpo_stampanti { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Se a True la postazione ha accesso al lettore di card. È selezionata a True in automatico quando viene inserito un record sulla tabella relativa. Deve essere riportato a False se poi il record in tabella viene cancellato.")]
        public bool tpo_card { get; set; }

        [SwaggerSchema(Description = "Campo Bit. Se a True l’Utente NON ha più accesso alla postazione.")]
        public bool tpo_annullato { get; set; }

        [SwaggerSchema(Description = "Lista delle stampanti associate.")]
        public List<StampePostazioniDTO> StampePostazioni { get; set; } = new List<StampePostazioniDTO>();

        [SwaggerSchema(Description = "Lista dei registratori fiscali associati.")]
        public List<FiscalePostazioniDTO> FiscalePostazioni { get; set; } = new List<FiscalePostazioniDTO>();

        [SwaggerSchema(Description = "Lista dei lettori di card associati.")]
        public List<LettorePostazioniDTO> LettorePostazioni { get; set; } = new List<LettorePostazioniDTO>();
    }
}
