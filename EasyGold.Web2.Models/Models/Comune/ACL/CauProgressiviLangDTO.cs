using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class CauProgressiviLangDTO
    {
        public int Prcid_ISONum { get; set; }
        public int Prcid_ID { get; set; }
        [StringLength(50)]
        public string Prcid_Descrizione { get; set; }
    }
}