using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
{
    public class TagProdottiDTO
    {
        public int? Etp_IDAuto { get; set; }

        [Required]
        public string Etp_Descrizione { get; set; }

        [StringLength(16)]
        public string? Etp_ColEtichetta { get; set; }
        public int? Etp_TipoEtichetta { get; set; }

        public bool? Etp_InEvidenza { get; set; }

        public bool? Etp_Annullato { get; set; }
    }
}