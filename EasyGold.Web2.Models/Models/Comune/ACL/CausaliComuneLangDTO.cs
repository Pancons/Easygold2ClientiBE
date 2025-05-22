using System.ComponentModel.DataAnnotations;

namespace EasyGold.Web2.Models.Comune.ACL
{
    public class CausaliComuneLangDTO
    {
        public int Cac_id_ISONum { get; set; }
        public int Cac_id_ID { get; set; }
        [StringLength(100)]
        public string Cac_id_Descrizione { get; set; }
    }
}