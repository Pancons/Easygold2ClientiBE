using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
    /// <summary>
    /// DTO per Registro IVA.
    /// </summary>
    public class RegistroIVADTO
    {
        public int? RowIdAuto { get; set; }

        [Required]
        [StringLength(50)]
        public string Rgi_Descrizione { get; set; }

        [StringLength(10)]
        public string Rgi_Prefisso { get; set; }

        [StringLength(10)]
        public string Rgi_Suffisso { get; set; }

        public bool Rgi_Annulla { get; set; }
    }
}