using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    public class PermessiGruppoDTO
    {
        [SwaggerSchema(Description = "Campo Numerico Intero Auto")]
        public int Abg_IDAuto { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il campo grp_IDAuto della tabella dbo.tbcl_gruppi.")]
        public int Abg_IDGruppo { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il campo abl_IDAuto della tabella dbo.tbco_funzioni a cui si vuole attribuire una abilitazione. L’abilitazione scelta sarà inserita automaticamente da Easygold alla voce selezionata e a tutte quelle sotto.")]
        public int Abg_IDFunzione { get; set; }

        [SwaggerSchema(Description = "Campo Numerico Intero. È il valore del campo tpa_IDAuto della tabella dbo.tbco_tipoPermesso. Nella form è un campo Combo a Scelta Singola con ricerca della tabella dbo.tbco_tipoPermesso.")]
        public int Abg_IDTipoPermesso { get; set; }
    }
}
