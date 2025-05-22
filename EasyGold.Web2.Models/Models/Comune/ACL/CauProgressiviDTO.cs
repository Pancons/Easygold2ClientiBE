using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class CauProgressiviDTO
    {
        public int Cpr_IDAuto { get; set; }
        [StringLength(50)]
        public string Cpr_Descrizione { get; set; }
        public int Cpr_CalcGiacenza { get; set; }
        public int Cpr_CalcDisponibilita { get; set; }
        public bool Cpr_Annullato { get; set; }
    }
}