using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class GruppiDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto.")]
        public int Grp_IDAuto { get; set; }

        [SwaggerSchema(Description = "È il nome del Gruppo.")]
        [StringLength(50)]
        public string Grp_NomeGruppo { get; set; }

        [SwaggerSchema(Description = "È la descrizione estesa del Gruppo.")]
        [StringLength(100)]
        public string? Grp_DesGruppo { get; set; }

        [SwaggerSchema(Description = "Nella Form è un campo Check attivo solo se non esiste già un Gruppo SuperAmministratore.")]
        public bool? Grp_SuperAdmin { get; set; }

        [SwaggerSchema(Description = "Se è selezionato il Gruppo e di conseguenza gli Utenti collegati sono bloccati")]
        public bool? Grp_Bloccato { get; set; }
    }
}
