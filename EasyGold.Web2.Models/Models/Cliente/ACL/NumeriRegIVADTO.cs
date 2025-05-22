using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Principal;

namespace EasyGold.Web2.Models.Cliente.ACL
{
    /// <summary>
    /// DTO per Numeri Registro IVA.
    /// </summary>
    public class NumeriRegIVADTO
    {
        public int? RowIDAuto { get; set; }

        [Required]
        public int RowIDRegIVA { get; set; }

        [Required]
        public int Nri_Anno { get; set; }

        [Required]
        public int Nri_NumFattura { get; set; }
    }
}