using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class FunzioniDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Abl_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Abl_IDPadre { get; set; }

        [SwaggerSchema(Description = "È la descrizione della Funzione di Easygold.")]
        [StringLength(50)]
        public string Abl_DescFunzione { get; set; }

        [SwaggerSchema(Description = "È la descrizione estesa della Funzione di Easygold.")]
        [StringLength(150)]
        public string Abl_DescFunzioneEstesa { get; set; }

        [SwaggerSchema(Description = "Check per vedere se è stato annullato")]
        public bool? Abl_Annullato { get; set; }

        [SwaggerSchema(Description = "Lista dei permessi associati alle funzioni.")]
        public List<PermessiGruppoDTO> PermessiGruppo { get; set; } = new List<PermessiGruppoDTO>();
    }
}
