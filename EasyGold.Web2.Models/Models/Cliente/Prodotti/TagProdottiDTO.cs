using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Cliente.Prodotti
{
    /// <summary>
    /// DTO per i tag prodotti.
    /// </summary>
    public class TagProdottiDTO
    {
        public int? Etp_IDAuto { get; set; }

        [StringLength(100)]
        public string Etp_Descrizione { get; set; }

        [StringLength(16)]
        public string? Etp_ColEtichetta { get; set; }

        [StringLength(16)]
        public string? Etp_ColSfondo { get; set; }

        public int? Etp_TipoEtichetta { get; set; }

        public bool? Etp_InEvidenza { get; set; }

        public bool? Etp_Annullato { get; set; }
    }
}
