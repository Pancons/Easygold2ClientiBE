using System.ComponentModel.DataAnnotations;

namespace EasyGold.API.Models.DTO.NumeriRegIVA
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