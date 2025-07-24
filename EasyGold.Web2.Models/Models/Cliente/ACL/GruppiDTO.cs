using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{

    /// Inserire una gruppi utenti. 
    
    /// <summary>
    /// DTO per Gruppi.
    /// </summary>
    public class GruppiDTO
    {
        [SwaggerSchema(Description = "ID auto-incrementale gruppo.")]
        public int Grp_IDAuto { get; set; }

        [SwaggerSchema(Description = "Nome del gruppo.")]
        [StringLength(50)]
        public string Grp_NomeGruppo { get; set; }

        [SwaggerSchema(Description = "Descrizione estesa del gruppo.")]
        [StringLength(100)]
        public string Grp_DesGruppo { get; set; }

        [SwaggerSchema(Description = "Super amministratore.")]
        public bool?  Grp_SuperAdmin { get; set; }

        [SwaggerSchema(Description = "Gruppo bloccato.")]
        public bool? Grp_Bloccato { get; set; }

        
        [SwaggerSchema(Description = "Lista degli ID degli utenti appartenenti al gruppo.")]
        public List<UtenteDTO> Utenti { get; set; } = new List<UtenteDTO>();

        [SwaggerSchema(Description = "Lista degli ID delle abilitazioni associate al gruppo.")]
        public List<PermessiGruppoDTO> Permessi { get; set; } = new List<PermessiGruppoDTO>();
    }

    
}